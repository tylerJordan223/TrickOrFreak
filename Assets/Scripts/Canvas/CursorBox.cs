using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CursorBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] UnityEvent onClick;
    private bool isMouseOver = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked");
        onClick.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Inside Area");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Outside Area");
    }
}
