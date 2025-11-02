using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HouseSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int choiceNumber;
    private Image my_choice;
    private Animator anim;
    private bool active;

    private void Awake()
    {
        active = false;
        anim = GetComponent<Animator>();
        my_choice = GetComponent<Image>();
        my_choice.color = new Color(255f, 0f, 0f, 0f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(choiceNumber == WorldEffects.GetFreakNum())
        {
            //good ending
        }
        else
        {
            //bad ending
        }

        StartCoroutine(Transition());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!active)
        {
            my_choice.color = new Color(255f, 0f, 0f, 0.1f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!active)
        {
            Debug.Log("doing");
            my_choice.color = new Color(255f, 0f, 0f, 0f);
        }
    }

    IEnumerator Transition()
    {
        my_choice.color = new Color(255f, 255f, 255f, 1f);
        active = true;
        anim.SetBool("explode", true);
        yield return new WaitForSeconds(0.3f);
        WorldEffects.DeleteHouse(choiceNumber);
        yield return new WaitForSeconds(1f);
        anim.SetBool("explode", false);
        active = false;
        transform.parent.parent.parent.parent.GetComponent<MenuScript>().GoToEnd();
    }
}
