using UnityEngine;
using TMPro;

public class Notification : VisibilityComponent
{
    CanvasGroup visibilityComp;
    TextMeshProUGUI panelText;
    
    void Start()
    {
        visibilityComp = GetComponent<CanvasGroup>();
        panelText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }
    public void Display(string text)
    {
        panelText.SetText(text);
        SetVisibility(visibilityComp, true);
    }
    public void Undisplay()
    {
        SetVisibility(visibilityComp, false);
    }
}
