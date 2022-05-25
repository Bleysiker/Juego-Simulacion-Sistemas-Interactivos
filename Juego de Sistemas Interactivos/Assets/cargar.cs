using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cargar : MonoBehaviour
{
    [SerializeField] AudioSource sonidoBoton;
    public void CargarJuego()
    {
        StartCoroutine("Cargar");
    }
    IEnumerator Cargar()
    {
        sonidoBoton.Play();
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Main");
    }
}
