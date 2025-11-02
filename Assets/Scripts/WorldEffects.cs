using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEffects : MonoBehaviour
{
    public static WorldEffects instance;

    [SerializeField]
    GameObject[] plots;
    [SerializeField] GameObject[] possible_houses;
    [SerializeField] GameObject[] evil_houses;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            PopulatePlots();
        }
        else
        {
            Destroy(this);
        }
    }

    public void PopulatePlots()
    {
        List<int> possibilities = new List<int>();
        for(int i = 0; i < possible_houses.Length; i++)
        {
            possibilities.Add(i);
        }

        System.Random rand = new System.Random();

        //pick a random freak  house
        int freak_house = rand.Next(plots.Length);

        for(int f = 0; f < plots.Length; f++)
        {
            if(f != freak_house)
            {
                int temp = rand.Next(possibilities.Count);
                Debug.Log(possibilities[temp]);
                GameObject h = Instantiate(possible_houses[possibilities[temp]]);
                h.transform.parent = plots[f].transform;
                h.transform.SetLocalPositionAndRotation(new Vector3(0, 0.15f, 0), Quaternion.Euler(0,270,0));
                possibilities.Remove(possibilities[temp]);
            }
            else
            {
                int temp = rand.Next(possibilities.Count);
                Debug.Log(possibilities[temp]);
                GameObject h = Instantiate(evil_houses[possibilities[temp]]);
                h.transform.parent = plots[f].transform;
                h.transform.SetLocalPositionAndRotation(new Vector3(0, 0.15f, 0), Quaternion.Euler(0, 270, 0));
                possibilities.Remove(possibilities[temp]);
            }
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
