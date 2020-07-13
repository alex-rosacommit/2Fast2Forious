using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MotorCarreteras : MonoBehaviour
{
    public GameObject contenedorCallesGO;
    public GameObject[] contenedorCallesArray;
    public GameObject MiCamGO;
    public Camera miCamara;
    public GameObject cocheGO;
    public GameObject sonidoFX;
    public AudioFX sonidoFXScript;
    public GameObject bgGameOver;

    public float velocidad;
    public bool inicioJuego;
    public bool juegoTerminado;

//Referencias para identificar las calles que se van creando o se van eliminando
    public int contadorCalles = 0;
    public int selectorCalles;

    public GameObject calleAnterior;
    public GameObject calleNueva;

    public float tamañoCalle;
    public Vector3 medidaLimitePantalla;
    public bool salioDePantalla;

    // Start is called before the first frame update
    void Start()
    {        
        InicioJuego();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inicioJuego == true && juegoTerminado == false)
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);

            if (calleAnterior.transform.position.y + tamañoCalle < medidaLimitePantalla.y && salioDePantalla == false)
            {
                salioDePantalla = true;
                DestruyoCalles();
            }
        }
    }

    private void InicioJuego()
    {
        contenedorCallesGO = GameObject.Find("ContenedorCalles");

        MiCamGO = GameObject.Find("MainCamera");
        miCamara = MiCamGO.GetComponent<Camera>();
        cocheGO = GameObject.FindObjectOfType<Coche>().gameObject;
        sonidoFX = GameObject.FindObjectOfType<AudioFX>().gameObject;
        sonidoFXScript = sonidoFX.GetComponent<AudioFX>();
        bgGameOver = GameObject.Find("PanelGameOver");
        bgGameOver.SetActive(false);

        VelocidadMotorCarretera();
        MedirPantalla();
        BuscoCalles();
    }

    private void VelocidadMotorCarretera()
    {
        velocidad = 18;
    }

    private void BuscoCalles()
    {
        contenedorCallesArray = GameObject.FindGameObjectsWithTag("Calle");

        
        for(int i = 0; i < contenedorCallesArray.Length; i ++)
        {
            //Hacemos que la calle dentro del array sea hijo de "ContenedorCalles".
            contenedorCallesArray[i].gameObject.transform.SetParent(contenedorCallesGO.transform);
            //Asiganamos el nombre a la calle.
            contenedorCallesArray[i].gameObject.name = "CalleOff_" + i;
            //Desacativamos la renderizacion de la calle
            contenedorCallesArray[i].gameObject.SetActive(false);

        }

        CrearCalles();        
    }

    private void CrearCalles()
    {
        contadorCalles++;
        selectorCalles = Random.Range(0, contenedorCallesArray.Length);

        GameObject Calle = Instantiate(contenedorCallesArray[selectorCalles]);
        Calle.SetActive(true);
        Calle.name = "Calle" + contadorCalles;
    //Hacemos que el GameObjet "Calle" sea hijo de "this(MotorCarreteras)"
        Calle.transform.SetParent(this.transform);
        PosicionoCalles();
    }

    private void PosicionoCalles()
    {
        calleAnterior = GameObject.Find("Calle" + (contadorCalles-1));
        calleNueva = GameObject.Find("Calle" + contadorCalles);

        MedirCalles();
    //Con un nuevo Vector3 Posicionamos la calle nueva donde finaliza la calle anterior mediaante el eje Y.
        calleNueva.transform.position = new Vector3(calleAnterior.transform.position.x, calleAnterior.transform.position.y + tamañoCalle, 0);
        salioDePantalla = false;
    }

    private void MedirCalles()
    {
        for (int i = 0; i< calleAnterior.transform.childCount; i++)
        {
            if (calleAnterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null)
            {
                float tamañoPieza = calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                tamañoCalle = tamañoCalle + tamañoPieza;
            }            
        }
    }

    private void MedirPantalla()
    {
        medidaLimitePantalla = new Vector3(0,miCamara.ScreenToWorldPoint(new Vector3(0,0,0)).y - 0.5f, 0);
    }

    private void DestruyoCalles()
    {
        Destroy(calleAnterior);
        calleAnterior = null;
        tamañoCalle = 0;
        CrearCalles();
    }
    
    public void JuegoTerminadoEstados()
    {
        cocheGO.GetComponent<AudioSource>().Stop();
        sonidoFXScript.FXmusic();
        bgGameOver.SetActive(true);
    }

}
