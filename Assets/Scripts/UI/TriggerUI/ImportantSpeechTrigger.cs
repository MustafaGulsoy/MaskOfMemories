using UnityEngine;

public class ImportantSpeechTrigger : NPCInteraction
{
    ImportantSpeech importantSpeech;
    [SerializeField] string[] names = {"Ali", "Veli", "Ali", "Veli"};
    [SerializeField] string[] content = {"Sa", "As", "Hg", "Hb"};
    void Start()
    {
        importantSpeech = GameObject.Find("ImportantSpeech").GetComponent<ImportantSpeech>();
        interactionFunc = ImportText;
        interactionKey = KeyCode.E;
    }

    void ImportText()
    {
        importantSpeech.StartDialogue(names, content);
    }
}
