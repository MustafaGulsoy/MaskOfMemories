using UnityEngine;
public class InGameMenu : VisibilityComponent
{
    CanvasGroup visibilityComp;
    void Start()
    {
        visibilityComp = GetComponent<CanvasGroup>();
    }
    public void Display(bool status)
    {
        SetVisibility(visibilityComp, status);
    }
}
