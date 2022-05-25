using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReiniciarValores : MonoBehaviour
{
   
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PlayerPrefs.SetInt("Tutorial", 0);
            Debug.Log("Tutorial Reiniciado");
        }
    }
}
