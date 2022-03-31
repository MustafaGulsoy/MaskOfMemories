using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeechBubble : VisibilityComponent
{

    //Speech bubble is a prefab which will be created when speech bubble trigger is triggered.
    TextMeshPro panelText;
    List<SpriteRenderer> visibilityComps = new List<SpriteRenderer>();
    void Awake()
    {
        visibilityComps.Add(transform.GetChild(0).GetComponent<SpriteRenderer>());
        panelText = transform.GetChild(1).GetComponent<TextMeshPro>();
    }
    public void SetThenDisplay(string text)
    {
        panelText.SetText(text);
        SetVisibility(visibilityComps, true);
    }
    public void Undisplay()
    {
        SetVisibility(visibilityComps, false);
    }
}
