using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    public AudioClip[] fxs;
    public AudioSource audioS;
    /*
     * 0 Efecto Choque
     * 1 Musica fin de juego
     */

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FXsonidoChoque()
    {
        gameObject.GetComponent<AudioSource>().clip = fxs[0];
        audioS.Play();
    }

    public void FXmusic()
    {
        audioS.clip = fxs[1];
        audioS.Play();
    }

}
