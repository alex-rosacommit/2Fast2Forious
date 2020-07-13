using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{
    public GameObject motorCarreterasGO;
    public MotorCarreteras motorCarreterasScript;
    public Sprite[] numeros;

    public GameObject contadorNumerosGO;
    public SpriteRenderer contadorNumerosComp;

    public GameObject controladorCocheGO;
    public GameObject cocheGO;



    // Start is called before the first frame update
    void Start()
    {
        InicioComponentes();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InicioComponentes()
    {
        motorCarreterasGO = GameObject.Find("MotorCarreteras");
        motorCarreterasScript = motorCarreterasGO.GetComponent<MotorCarreteras>();

        contadorNumerosGO = GameObject.Find("ContadorNumeros");
        contadorNumerosComp = contadorNumerosGO.GetComponent<SpriteRenderer>();

        controladorCocheGO = GameObject.Find("ControladorCoche");
        cocheGO = GameObject.Find("Coche");

        InicioCuentaAtras();
    }

    private void InicioCuentaAtras()
    {
        StartCoroutine(Contando());
    }

    IEnumerator Contando()
    {
        controladorCocheGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        contadorNumerosComp.sprite = numeros[1];
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosComp.sprite = numeros[2];
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosComp.sprite = numeros[3];
        motorCarreterasScript.inicioJuego = true;
        contadorNumerosGO.GetComponent<AudioSource>().Play();
        cocheGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        contadorNumerosGO.SetActive(false);
    }

}
