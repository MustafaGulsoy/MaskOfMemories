using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    /*
    Every trigger box inherits this class to control creation, deletion trigger panel
    */


    // General declaration for being able to use different functions to display relative UI element and update it's text.
    protected delegate void SetAndDisplay();
    protected delegate void Undisplay();

    // If there is no need to declare these functions they will print these info
    protected SetAndDisplay BeginTrigger = () =>
        {
            Debug.Log("Empty Trigger SetAndDisplay Function");
        };
    protected Undisplay ExitTrigger = () =>
        {
            Debug.Log("Empty Trigger Undisplay Function");
        };
    //

    protected bool isPlayerInTrigger;

    protected void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            BeginTrigger();
            isPlayerInTrigger = true;
        }
    }
    protected void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            ExitTrigger();
            isPlayerInTrigger = false;
        }
    }
}
