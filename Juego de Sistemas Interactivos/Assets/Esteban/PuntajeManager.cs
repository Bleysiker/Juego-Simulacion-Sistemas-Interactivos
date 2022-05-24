using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuntajeManager : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;
     TMP_Text scoreMejorado;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        scoreMejorado = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
       
        score.text = "Score" + scoreValue;
    }
}
