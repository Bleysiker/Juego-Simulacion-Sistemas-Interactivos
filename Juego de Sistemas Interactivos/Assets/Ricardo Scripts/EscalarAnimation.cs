using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalarAnimation : MonoBehaviour
{
    [SerializeField] float aparicion;
    void Start()
    {
        transform.LeanScale(Vector3.one,aparicion).setEaseInOutExpo();
    }
}
