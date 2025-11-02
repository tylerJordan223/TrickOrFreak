using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CursorBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] UnityEvent onClick;
    [SerializeField] UnityEvent onHover;
    [SerializeField] UnityEvent onNotHover;

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(onHover != null)
        {
            onHover.Invoke();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(onNotHover != null)
        {
            onNotHover.Invoke();
        }
    }
}
