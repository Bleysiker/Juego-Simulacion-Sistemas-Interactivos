using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuntajeManager : MonoBehaviour
{
    public static int scoreValue = 0;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] int[] valores;
    [SerializeField] int cont;
    [SerializeField] Eventos ganarPuntos,masMeteoritos;
    // Start is called before the first frame update
    private void Start()
    {
        cont = 0;
        score.text = "Score: " + scoreValue;
        ganarPuntos.GEvent += SumarPuntos;
    }
    void SumarPuntos()
    {
        scoreValue += 10;
        score.text = "Score: " + scoreValue;
        if (cont < valores.Length)
        {
            if (scoreValue >= valores[cont])
            {
                masMeteoritos.FireEvent();
                cont++;
            }
        }
        
    }
    private void OnDestroy()
    {
        ganarPuntos.GEvent -= SumarPuntos;
    }
}

