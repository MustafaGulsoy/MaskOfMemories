using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XNode;

public class NodeParser : MonoBehaviour
{
    public DialogueGraph graph;
    Coroutine _parser;
    public Text speaker;
    public Text dialogue;
    public Image speakerImage;

    private void Start()
    {
        foreach (BaseNode b in graph.nodes)
        {
              Debug.Log(b);
            if(b.GetString() == "Start")
            {
            graph.current = b;
          
            break;
            }
        }
     //   _parser = StartCoroutine(ParseNode());

    }

    IEnumerable ParseNode()
    {
        BaseNode b = graph.current;
        string data = b.GetString();
        string[] dataParts = data.Split('/');

        if(dataParts[0] == "Start")
        {
            NextNode("exit");
        }
        if (dataParts[0] == "DialogueNode")
        {
            speaker.text = dataParts[1];
            dialogue.text = dataParts[2];
            speakerImage.sprite = b.GetSprite();
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
            NextNode("exit");
        }
    }
    public void NextNode(string fieldName)
    {
        if(_parser != null)
        {
            StopCoroutine(_parser);
            _parser = null;

        }
        foreach (NodePort p in graph.current.Ports)
        {
            graph.current = p.Connection.node as BaseNode;
            break;
        }
    //    _parser = StartCoroutine(ParseNode());

    }
}
