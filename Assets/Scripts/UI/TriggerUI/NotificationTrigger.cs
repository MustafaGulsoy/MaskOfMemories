using UnityEngine;

public class NotificationTrigger : TextTrigger
{
    Notification notification;
    void Start()
    {
        notification = GameObject.Find("Notification").GetComponent<Notification>();
        BeginTrigger = Display;
        ExitTrigger = () =>
        {
            Debug.Log("Empty NotificationTrigger Undisplay Function");
        };
    }
    void Update()
    {
        if(isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Destroy();
        }
    }
    void Display() // Sets game paused and displays notification panel
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().SetIsGameStopped(true);
        notification.Display(text);
    }
    void Destroy() // Sets game unpaused then Destroys both notification panel and trigger
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().SetIsGameStopped(false);
        notification.Undisplay();
        Destroy(gameObject);
    }
}
