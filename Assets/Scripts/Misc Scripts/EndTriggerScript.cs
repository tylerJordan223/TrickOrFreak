using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTriggerScript : MonoBehaviour
{
    [SerializeField]public GameObject DecisionCanvas;
    private bool flag;

    private void Awake()
    {
        //DecisionCanvas = GameObject.Find("Decision");
        flag = true;
        DecisionCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(flag)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            DecisionCanvas.SetActive(true);
            WorldEffects.DisablePlayer();
            flag = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        flag = true;
    }

    public void DecisionNO()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        DecisionCanvas.SetActive(false);
        WorldEffects.EnablePlayer();
    }

    public void DecisionYES()
    {
        flag = true;
        DecisionCanvas.SetActive(false);
    }
}
