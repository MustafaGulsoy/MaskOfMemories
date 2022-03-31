using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public void ResumeGame()
    {
        GameObject.Find("EventSystem").GetComponent<EventSystem>().ToggleInGameMenu();
    }
}
