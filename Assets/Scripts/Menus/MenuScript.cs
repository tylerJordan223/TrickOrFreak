using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject mainmenu;

     //MainMenu Functions
     public void StartGame()
    {
        mainmenu.gameObject.SetActive(false);
        WorldEffects.EnablePlayer();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
