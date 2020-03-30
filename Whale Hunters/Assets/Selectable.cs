using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public class Selectable : MonoBehaviour, ISelectHandler, IPointerClickHandler, IDeselectHandler {

    public static HashSet<Selectable> selectables = new HashSet<Selectable>();
    public static HashSet<Selectable> selected = new HashSet<Selectable>();

    //define my appearances here (selected vs. unselected)

    void Awake()
    {
        selectables.Add(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnSelect(eventData);
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
        {
            DeselectAll(eventData);
        }
        selected.Add(this);
        //change my appearance here
    }

    public void OnDeselect(BaseEventData eventData)
    {
        //change my appearance here
    }

    public static void DeselectAll(BaseEventData eventData)
    {
        foreach (Selectable s in selected)
        {
            s.OnDeselect(eventData);
        }

        selected.Clear();
    }
}
