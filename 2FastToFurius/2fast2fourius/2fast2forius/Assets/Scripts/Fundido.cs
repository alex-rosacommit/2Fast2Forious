using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fundido : MonoBehaviour
{
    public Image fundido;
    public string[] nombreEscenas;



    // Start is called before the first frame update
    void Start()
    {
        fundido.CrossFadeAlpha(0, 0.5f, false);        
    }
 
    public void FadeOut(int numEscena)
    {
        fundido.CrossFadeAlpha(1, 0.5f, false);
        StartCoroutine(CambioEscena(nombreEscenas[numEscena]));
    }

    IEnumerator CambioEscena(string escena)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(escena);
    }

}
