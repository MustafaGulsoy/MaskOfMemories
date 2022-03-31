using System.Collections;
using UnityEngine;
using TMPro;

public class ImportantSpeech : VisibilityComponent
{
    CanvasGroup visibilityComp;
    TextMeshProUGUI speakerNameText;
    TextMeshProUGUI contentText;
    bool isInDialouge = false;
    
    void Start()
    {
        visibilityComp = GetComponent<CanvasGroup>();
        speakerNameText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        contentText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }
    public void StartDialogue(string[] names, string[] content)
    {
        if(isInDialouge)
            return;
            
        StartCoroutine(DisplayDialogue());
        
        IEnumerator DisplayDialogue() // Because I use coroutine here, I must access GameManager to stop the game.
        {                             // More easily accessible if GameManager is static.
            isInDialouge = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().SetIsGameStopped(true);
            SetVisibility(visibilityComp, true);
            int dialougeLength = content.Length;
            for(int i = 0; i < dialougeLength; i++)
            {
                speakerNameText.SetText(names[i]);
                contentText.SetText(content[i]);
                yield return new WaitForSeconds(0.05f);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            }
            SetVisibility(visibilityComp, false);
            GameObject.Find("GameManager").GetComponent<GameManager>().SetIsGameStopped(false);
            yield return new WaitForSecondsRealtime(0.5f);
            isInDialouge = false;
        }
    }
}
