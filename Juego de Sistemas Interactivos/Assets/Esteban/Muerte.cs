using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerte : MonoBehaviour
{
    [SerializeField] GameObject MenuMuerte;

    public void Update()
    {
        

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Meteorito"))
        {
            MenuMuerte.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Muerto()
    {
        MenuMuerte.SetActive(true);
        Time.timeScale = 0f;
        // Debug.Log("pausado");

    }

    public void Restart()
    {
        SceneManager.LoadScene("Esteban");
        MenuMuerte.SetActive(false);
        Time.timeScale = 1f;
        //Debug.Log("Jugando");

    }
}
