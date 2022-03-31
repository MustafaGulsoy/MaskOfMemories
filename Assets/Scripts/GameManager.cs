using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isInGame = false;
    bool isGameStopped = false;
    
    public bool IsInGame() // Provides to check game status
    {
        return isInGame;
    }
    public void SetIsInGame(bool status) // Sets the game's status
    {
        isInGame = status;
    }
    public bool IsGameStopped()
    {
        return isGameStopped;
    }
    public void SetIsGameStopped(bool status)
    {
        isGameStopped = status;
    }
}
