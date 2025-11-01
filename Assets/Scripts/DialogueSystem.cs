using EasyTextEffects;
using EasyTextEffects.Effects;
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
    [SerializeField] Color text_color;
    [SerializeField] public TextEffectInstance effect;
    [Range(1,10)] public float talkspeed;

    private bool endFlag;
    private bool talking;
    private int dialogue_index;

    //runs every ttime this is enabled
    private void OnEnable()
    {
        //apply the text color
        text_object.color = text_color;

        if (dialogue_arr.Length > 0)
        {
            //play the first piece of dialogue
            dialogue_index = 0;
            StartCoroutine(do_dialogue(dialogue_arr[dialogue_index]));
        }
    }

    private void Update()
    {
        //update to skip to the end
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(!endFlag)
            {
                endFlag = true;
            }
            if(endFlag && !talking)
            {
                dialogue_index++;
                if (dialogue_index < dialogue_arr.Length)
                {
                    StartCoroutine(do_dialogue(dialogue_arr[dialogue_index]));
                }
                else
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnDisable()
    {
        text_object.GetComponent<TextEffect>().StopManualEffects();
    }

    //actually play the dialogue
    IEnumerator do_dialogue(string s)
    {
        talking = true;
        text_object.text = "                                                                                                             ";
        text_object.GetComponent<TextEffect>().globalEffects[0].effect = effect;
        text_object.GetComponent<TextEffect>().Refresh();
        text_object.enabled = false;
        yield return new WaitForSeconds(0.5f);
        endFlag = false;
        text_object.enabled = true;
        text_object.GetComponent<TextEffect>().StartManualEffects();

        for(int i = 0; i < s.Length; i++)
        {
            text_object.text = s.Substring(0, i+1);

            if(endFlag)
            {
                i = s.Length;
                text_object.text = s.Substring(0, i);
            }

            yield return new WaitForSeconds(talkspeed / 50);
        }

        talking = false;
    }
}