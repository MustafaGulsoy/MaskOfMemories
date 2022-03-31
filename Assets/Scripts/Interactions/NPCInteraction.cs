using UnityEngine;

public class NPCInteraction : TriggerBox
{
    /*
        When a class inherits this class you should adjust the game object's rigidbody's sleeping mode as start asleep for optimization.
        The game object is which you add the inheritor class as a component.
    */
    protected KeyCode interactionKey; // In inspector you can choose which key should activate interaction function.
    protected delegate void InteractionFunc();
    protected InteractionFunc interactionFunc = () =>
        {
            Debug.Log("Empty NPCInteraction Interaction Function");
        };
    virtual protected void Awake()
    {
        // Thanks to inherited class, it will wake up when player collides to the npc and sleep when collision ends. 
        BeginTrigger = () =>
        {
            this.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
        };
        ExitTrigger = () =>
        {
            this.GetComponent<Rigidbody2D>().Sleep();
        };
    }
    void Update()
    {
        if(isPlayerInTrigger && Input.GetKeyDown(interactionKey))
        {   
            interactionFunc();
        }
    }
}
