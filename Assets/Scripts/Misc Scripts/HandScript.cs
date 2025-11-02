using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    private RectTransform hand;
    private Canvas me;

    private void Awake()
    {
        me = transform.parent.GetComponent<Canvas>();
        hand = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            me.GetComponent<RectTransform>(),
            Input.mousePosition,
            me.worldCamera,
            out localPoint
            );

        hand.localPosition = new Vector3(localPoint.x, localPoint.y - 100f, 0f);

        if(Input.GetMouseButton(0))
        {
            hand.localRotation = Quaternion.Euler(40f, 0f, 0f);
        }
        else
        {
            hand.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
