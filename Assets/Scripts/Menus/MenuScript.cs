using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject mainmenu;
    [SerializeField] GameObject decisionMenu;
    [SerializeField] GameObject endMenu;

    //MainMenu Functions
    public void StartGame()
    {
        mainmenu.gameObject.SetActive(false);
        WorldEffects.EnablePlayer();
    }

    public void goToStart()
    {
        endMenu.SetActive(false);
        mainmenu.gameObject.SetActive(true);
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

    public void GoToEnd()
    {
        decisionMenu.SetActive(false);
        endMenu.SetActive(true);
    }
}
