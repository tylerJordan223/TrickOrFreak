using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] Canvas door_canvas;
    private AudioSource knock;

    int knocks;

    private void Start()
    {
        knock = GetComponent<AudioSource>();
        knocks = 0;
    }

    public void Knock()
    {
        knocks++;
        knock.Play();
        if (knocks == 3)
        {
            door_canvas.gameObject.SetActive(false);
            transform.parent.GetComponent<HouseScript>().OpenDoor();
            WorldEffects.instance.HandvasOff();
            knocks = 0;
        }
    }

    public void ActivateDoor()
    {
        Cursor.visible = false;
        door_canvas.gameObject.SetActive(true);
        WorldEffects.instance.HandvasOn();
    }
}
