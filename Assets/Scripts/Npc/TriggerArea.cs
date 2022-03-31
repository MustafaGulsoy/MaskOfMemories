using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    private npc npc;
 
    private void Awake()
    {
        npc = GetComponentInParent<npc>();
    }
 
 
 

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { npc.inRangePlayer = false; }

    }
 

}
