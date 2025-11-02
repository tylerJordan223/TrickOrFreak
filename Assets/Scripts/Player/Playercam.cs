using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercam : MonoBehaviour
{
    public float senseX;
    public float senseY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    [SerializeField] GameObject e_alert;

    //also do this whenever its enabled
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        //get mouse input
        float MouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senseX;
        float MouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senseY;

        yRotation += MouseX;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate camera 
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        //raycast in direction
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 3f, LayerMask.GetMask("Interactable")))
        {
            e_alert.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                e_alert.SetActive(false);
                WorldEffects.DisablePlayer();
                //run interactable event
                hit.transform.GetComponent<Interactable>().RunEvent();
            }
        }
        else
        {
            e_alert.SetActive(false);
        }
    }
}
