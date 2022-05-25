using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerte : MonoBehaviour
{
    [SerializeField] GameObject MenuMuerte;
    [SerializeField] AudioSource grito,boton;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Meteorito"))
        {
            Time.timeScale = 0.1f;
            StartCoroutine("Morir");
        }
    }

    /*public void Muerto()
    {
        MenuMuerte.SetActive(true);
        Time.timeScale = 0f;
        // Debug.Log("pausado");

    }*/

    public void Restart()
    {
        StartCoroutine("Reiniciar");
    }
    IEnumerator Reiniciar()
    {
        boton.Play();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.1f);
        PuntajeManager.scoreValue = 0;
        SceneManager.LoadScene("Main");
        
    }
    IEnumerator Morir()
    {
        grito.Play();
        MenuMuerte.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0f;
        
    }
}
