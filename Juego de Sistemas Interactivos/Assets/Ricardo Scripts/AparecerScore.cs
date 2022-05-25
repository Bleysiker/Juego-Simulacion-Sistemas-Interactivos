using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerScore : MonoBehaviour
{
    [SerializeField] Eventos jugar;
    [SerializeField] CanvasGroup imagen;
    [SerializeField] float aparicion;
    void Start()
    {
        jugar.GEvent += Aparecer;
        if (PlayerPrefs.GetInt("Tutorial") > 0)
        {
            Aparecer();
        }
    }

    void Aparecer()
    {
        imagen.LeanAlpha(1, aparicion);
    }
    private void OnDestroy()
    {
        jugar.GEvent -= Aparecer;
    }
}
