using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaAnimation : MonoBehaviour
{
    [SerializeField] CanvasGroup imagen;
    [SerializeField] float aparicion;
    void Start()
    {
        imagen.LeanAlpha(1, aparicion);
    }
    
}
