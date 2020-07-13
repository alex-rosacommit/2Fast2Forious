using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buss : MonoBehaviour
{
    public GameObject cronometroGO;
    public Cronometro cronometroScript;

    public GameObject audioFX;
    public AudioFX audioFXScript;

    // Start is called before the first frame update
    void Start()
    {
        cronometroGO = GameObject.FindObjectOfType<Cronometro>().gameObject;
        cronometroScript = cronometroGO.GetComponent<Cronometro>();

        audioFX = GameObject.FindObjectOfType<AudioFX>().gameObject;
        audioFXScript = audioFX.GetComponent<AudioFX>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Coche>() != null)
        {
            audioFXScript.FXsonidoChoque();
            cronometroScript.tiempo =cronometroScript.tiempo - 20; 
            Destroy(this.gameObject);
        }
    }

}
