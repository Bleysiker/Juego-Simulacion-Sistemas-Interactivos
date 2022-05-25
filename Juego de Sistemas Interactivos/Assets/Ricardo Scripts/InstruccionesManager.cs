using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstruccionesManager : MonoBehaviour
{
    [SerializeField] GameObject[] textos;
    [SerializeField] Vector3 escalaInicial, escalaFinal;
    [SerializeField] float tiempoEntreTextos;
    [SerializeField] Eventos jugar;
    void Start()
    {
        textos[0].transform.localScale = escalaInicial;
        textos[1].transform.localScale = escalaInicial;
        if (PlayerPrefs.GetInt("Tutorial") < 1)
        {
            StartCoroutine("Instrucciones");
        }
    }

    IEnumerator Instrucciones()
    {
        textos[0].LeanScale(escalaFinal, 1f).setEaseInOutExpo();
        yield return new WaitForSeconds(tiempoEntreTextos);
        textos[1].LeanScale(escalaFinal, 1f).setEaseInOutExpo();
        yield return new WaitForSeconds(tiempoEntreTextos);
        jugar.FireEvent();
        textos[0].LeanScale(escalaInicial, 1f).setEaseInOutExpo();
        textos[1].LeanScale(escalaInicial, 1f).setEaseInOutExpo();
        PlayerPrefs.SetInt("Tutorial", 1);
    }
}
