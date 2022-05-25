using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteoritos : MonoBehaviour
{
    [SerializeField] GameObject[] meteoritos;
    [SerializeField] Eventos masMeteoritos;
    [SerializeField] int cont;
    // Update is called once per frame
    private void Start()
    {
        masMeteoritos.GEvent += SpawnMeteorito;
    }
    void SpawnMeteorito()
    {
        if (cont < meteoritos.Length)
        {
            meteoritos[cont].SetActive(true);
            cont++;
        }
    }
    private void OnDestroy()
    {
        masMeteoritos.GEvent -= SpawnMeteorito;
    }
}
