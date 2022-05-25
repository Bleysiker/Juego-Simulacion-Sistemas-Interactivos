using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritosIniciales : MonoBehaviour
{
    [SerializeField] GameObject[] meteoritos;
    [SerializeField] Eventos jugar;
    [SerializeField] float tiempoExplicacion;
    [SerializeField] int cont;
    void Start()
    {
        cont = 1;
        jugar.GEvent += Jugar;
        if (PlayerPrefs.GetInt("Tutorial") > 0)
        {
            tiempoExplicacion = 0;
            jugar.FireEvent();
        }
    }

    void Jugar()
    {
        StartCoroutine("ActivandoMeteoritos");
    }
    void SpawnMeteoritos()
    {
        if (cont < meteoritos.Length)
        {
            meteoritos[cont].SetActive(true);
            cont++;
            SpawnMeteoritos();
        }
    }
    IEnumerator ActivandoMeteoritos()
    {
        meteoritos[0].SetActive(true);
        yield return new WaitForSeconds(tiempoExplicacion);
        SpawnMeteoritos();
    }
    private void OnDestroy()
    {
        jugar.GEvent -= Jugar;
    }
}
