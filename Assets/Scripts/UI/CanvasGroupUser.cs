using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupUser : MonoBehaviour
{
    protected CanvasGroup canvasGroup;
    protected virtual void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    protected void SetVisibility(bool isVisible)
    {
        /* 
        To change the appearance of the panel, alpha value is changed
        */
        canvasGroup.alpha = Convert.ToInt32(isVisible);
        canvasGroup.interactable = isVisible;
        canvasGroup.blocksRaycasts = isVisible;
    }
}
