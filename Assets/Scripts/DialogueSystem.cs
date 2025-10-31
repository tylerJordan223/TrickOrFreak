using EasyTextEffects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    /*
     * System for Dialogue System
     * TO BE PUT ON A CANVAS
     * 
     * uses a single textmeshpro and handles the typing depending on the input
     */

    [Header("Dialogue Settings")]
    [SerializeField] public TextMeshProUGUI text_object;
    [SerializeField] public string[] dialogue_arr;
    [SerializeField] public float buffer_time;
    [Range(1,10)] public float talkspeed;

    //runs every ttime this is enabled
    private void OnEnable()
    {

        if (dialogue_arr.Length > 0)
        {
            //play the first piece of dialogue
            StartCoroutine(do_dialogue(dialogue_arr[0]));
        }
    }

    private void OnDisable()
    {
        text_object.GetComponent<TextEffect>().StopManualEffects();
    }

    //actually play the dialogue
    IEnumerator do_dialogue(string s)
    {
        text_object.text = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        text_object.GetComponent<TextEffect>().Refresh();
        text_object.enabled = false;
        yield return new WaitForSeconds(1f);
        text_object.enabled = true;
        text_object.GetComponent<TextEffect>().StartManualEffects();

        int sub_idx = 0;
        for(int i = 0; i <= s.Length; i++)
        {
            text_object.text = s.Substring(0, i);
            yield return new WaitForSeconds(talkspeed / 50);
        }
        yield return new WaitForSeconds(1f);
    }
}