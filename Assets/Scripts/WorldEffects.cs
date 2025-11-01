using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEffects : MonoBehaviour
{
    public static WorldEffects instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public static void DisablePlayer()
    {
        PlayerMovement.player.SetActive(false);
    }
    public static void EnablePlayer()
    {
        PlayerMovement.player.SetActive(true);
    }
}
