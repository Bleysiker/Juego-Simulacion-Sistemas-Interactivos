using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerApariciones : MonoBehaviour
{
    [SerializeField] GameObject[] objetosMenu;
    [SerializeField] AudioSource soundtrack, rugido;
    private void Start()
    {
        StartCoroutine("Apariciones");
    }
    IEnumerator Apariciones()
    {
        objetosMenu[0].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        objetosMenu[1].SetActive(true);
        rugido.Play();
        yield return new WaitForSeconds(4.3f);
        soundtrack.Play();
        objetosMenu[2].SetActive(true);
    }
}
