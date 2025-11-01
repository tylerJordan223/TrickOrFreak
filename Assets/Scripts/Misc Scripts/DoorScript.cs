using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] Canvas door_canvas;

    int knocks;

    private void Start()
    {
        knocks = 0;
    }


    public void Knock()
    {
        knocks++;
        if (knocks == 3)
        {
            door_canvas.gameObject.SetActive(false);
            transform.parent.GetComponent<HouseScript>().OpenDoor();
            knocks = 0;
        }
    }

    public void ActivateDoor()
    {
        door_canvas.gameObject.SetActive(true);
    }
}
