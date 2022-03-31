using UnityEngine;

public class TutorialTrigger : TextTrigger
{
    TutorialPanel tutorialPanel;
    void Start()
    {
        tutorialPanel = GameObject.Find("TutorialPanel").GetComponent<TutorialPanel>();
        BeginTrigger = SetThenDisplay;
        ExitTrigger = tutorialPanel.Undisplay;
    }
    void SetThenDisplay()
    {
        tutorialPanel.SetThenDisplay(text);
    }
}
