using UnityEngine;
using TMPro;

public class TutorialPanel : VisibilityComponent
{
    CanvasGroup visibilityComp;
    TextMeshProUGUI panelText;

    void Start()
    {
        visibilityComp = GetComponent<CanvasGroup>();
        panelText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    // Trigger box functions to control Tutorial Panel
    public void SetThenDisplay(string text)
    {
        panelText.SetText(text);
        SetVisibility(GetComponent<CanvasGroup>(),true);
    }
    public void Undisplay()
    {
        SetVisibility(visibilityComp, false);
    }
}
