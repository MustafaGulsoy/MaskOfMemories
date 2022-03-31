using UnityEngine;

public class SpeechBubbleTrigger : TextTrigger
{
    [SerializeField] GameObject speechBubblePrefab;
    SpeechBubble speechBubble;
    public bool isForPlayer = false; //If you want to make a bubble for player check it in inspector.
    void Start()
    {
        BeginTrigger = CreateSpeechBubble;
        ExitTrigger = DestroySpeechBubble;
    }
    protected void CreateSpeechBubble()
    {
        if (isForPlayer)               // Because Player is in test, I coded it like that. Normally, it should be as:
        {                             // GameObject.Find("Player").transform. 
            Transform playerTransform = GameObject.Find("Test").transform.GetChild(0).transform;
            speechBubble = Instantiate(speechBubblePrefab, playerTransform).GetComponent<SpeechBubble>();
        }
        else
        {
            speechBubble = Instantiate(speechBubblePrefab, transform).GetComponent<SpeechBubble>();
        }
        speechBubble.SetThenDisplay(text);

        Invoke("DestroySpeechBubble", 3f); // After bubble appears, it will fade out 3 seconds later.
    }
    protected void DestroySpeechBubble()
    {
        if(speechBubble)
            speechBubble.Undisplay();
    }
}
