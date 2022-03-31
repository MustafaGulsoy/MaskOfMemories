using UnityEngine;

public class StartButton : MonoBehaviour
{
    GameManager gameManager;
    GameObject startMenu;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        startMenu = GameObject.Find("StartMenu");
    }
    public void StartGame() 
    {
        gameManager.SetIsInGame(true);
        gameManager.SetIsGameStopped(false);
        Destroy(startMenu);
    }
}
