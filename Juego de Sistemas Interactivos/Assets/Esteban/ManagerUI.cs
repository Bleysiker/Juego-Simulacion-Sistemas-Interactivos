using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ManagerUI : MonoBehaviour
{
    public RectTransform mainMenu, Integrantes;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void IntegrantesUI()
    {
       
        mainMenu.DOAnchorPos(new Vector2(-1940, 0), 0.25f);
        Integrantes.DOAnchorPos(new Vector2(0, 0), 0.25f);

    }

    public void CloseIntegrantesUI()
    {
        
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
        Integrantes.DOAnchorPos(new Vector2(-1940, 0), 0.25f);
    }

    public void QuitGame()
    {
        Input.backButtonLeavesApp = true;
        Application.Quit();
    }
}
