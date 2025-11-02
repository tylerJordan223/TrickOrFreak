using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject mainmenu;
    [SerializeField] GameObject mainmenuCam;
    [SerializeField] GameObject decisionMenu;
    [SerializeField] GameObject decisionCam;
    [SerializeField] GameObject endMenu;
    [SerializeField] Image endImage;
    [SerializeField] Sprite endWin;
    [SerializeField] Sprite endLose;


    //MainMenu Functions
    public void StartGame()
    {
        mainmenu.gameObject.SetActive(false);
        mainmenuCam.gameObject.SetActive(false);
        PlayerMovement.player.transform.position = WorldEffects.instance.starting_position.position;
        WorldEffects.EnablePlayer();
    }

    public void goToStart()
    {
        endMenu.SetActive(false);
        WorldEffects.instance.PopulatePlots();
        mainmenuCam.SetActive(true);
        StartCoroutine(StartTransition());
    }

    public IEnumerator StartTransition()
    {
        yield return new WaitForSeconds(3f);
        mainmenu.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToDecision()
    {
        WorldEffects.DisablePlayer();
        decisionCam.SetActive(true);
        StartCoroutine(DecisionTransition());
    }

    public IEnumerator DecisionTransition()
    {

        yield return new WaitForSeconds(3f);
        decisionMenu.SetActive(true);
    }

    public void GoToEnd()
    {
        decisionMenu.SetActive(false);
        decisionCam.SetActive(false);

        if(WorldEffects.freakHouseNum == WorldEffects.instance.freakChoice)
        {
            endImage.sprite = endWin;
        }
        else
        {
            endImage.sprite = endLose;
        }

            StartCoroutine(EndTransition());
    }

    IEnumerator EndTransition()
    {
        endMenu.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        endMenu.GetComponent<Animator>().SetBool("Go", true);
    }
}
