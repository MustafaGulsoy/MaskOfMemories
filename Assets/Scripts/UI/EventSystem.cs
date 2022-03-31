using UnityEngine;

public class EventSystem : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleInGameMenu();
        }
    }
    public void ToggleInGameMenu()
    {   
        gameManager.SetIsGameStopped(!gameManager.IsGameStopped());
        GameObject.Find("InGameMenu").GetComponent<InGameMenu>().Display(gameManager.IsGameStopped());
    }
}
