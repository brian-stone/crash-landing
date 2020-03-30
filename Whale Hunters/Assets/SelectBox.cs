using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SelectBox : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private Vector2 startPos, endPos;
    private Rect box;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
        {
            Selectable.DeselectAll(new BaseEventData(EventSystem.current));
        }
        //boxImage.gameObject.SetActive(true);
        startPos = eventData.position;
        //box = new Rect();
    }

    public void OnDrag(PointerEventData eventData)
    {
        endPos = eventData.position;

        box.position = (startPos + endPos) / 2f;

        float w = Mathf.Abs(startPos.x - endPos.x);
        float h = Mathf.Abs(startPos.y - endPos.y);
        box.size = new Vector2(w, h);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //boxImage.gameObject.SetActive(false);
        foreach(Selectable s in Selectable.selectables)
        {
            s.OnSelect(eventData);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        float minDist = 0;

        foreach (RaycastResult r in results)
        {
            if (r.gameObject == gameObject)
            {
                minDist = r.distance;
                break;
            }
        }

        GameObject nextObject = null;
        float maxDist = Mathf.Infinity;

        foreach (RaycastResult r in results)
        {
            if (r.distance > minDist && r.distance < maxDist)
            {
                nextObject = r.gameObject;
                maxDist = r.distance;
            }
        }

        if (nextObject)
        {
            ExecuteEvents.Execute<IPointerClickHandler>(nextObject, eventData, (x, y) => { x.OnPointerClick((PointerEventData)y); });
        }

    }
}
