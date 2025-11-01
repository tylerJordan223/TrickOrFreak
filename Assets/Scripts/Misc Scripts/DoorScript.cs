using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera door_cam;
    [SerializeField] Canvas door_canvas;

    int knocks;

    private void Start()
    {
        knocks = 0;
    }

    //process for knocking
    public void SwapToDoorCam()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        door_cam.Priority = 1;
        door_canvas.gameObject.SetActive(true);
    }

    private void Update()
    {
        //if its enabled
        if(door_cam.Priority == 1)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                ReturnToPlayer();
            }
        }
    }

    public void Knock()
    {
        knocks++;
        if (knocks == 3)
        {
            ReturnToPlayer();
        }
    }

    public void ReturnToPlayer()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        door_cam.Priority = 0;
        door_canvas.gameObject.SetActive(false);
        WorldEffects.EnablePlayer();
    }
}
