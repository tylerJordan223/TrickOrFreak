using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject mainmenu;
    [SerializeField] GameObject decisionMenu;

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

    public void GoToDecision()
    {
        WorldEffects.DisablePlayer();
        decisionMenu.SetActive(true);
    }
}
