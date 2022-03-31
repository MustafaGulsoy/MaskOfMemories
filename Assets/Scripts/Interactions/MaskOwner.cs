using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskOwner : NPCInteraction
{
    GameObject player;
    bool maskTaken;
    bool quit = false;
    
    override protected void Awake()
    {                  // Because Player is in test, I coded it like that. Normally, it should be as:
        base.Awake();  // GameObject.Find("Player")
        player = GameObject.Find("Player");
        interactionFunc = MaskIsTaken;
        interactionKey = KeyCode.F;
        maskTaken = false;
    }
    void MaskIsTaken()
    {
        if (GetComponent<Animator>().runtimeAnimatorController)
        {   
            GetComponent<NpcController>().moveMode = false;
            player.GetComponent<Animator>().SetTrigger("takeMask"); 
   

            player.GetComponent<Animator>().runtimeAnimatorController = GetComponent<Animator>().runtimeAnimatorController;
            player.transform.localScale = transform.localScale;
            player.GetComponent<BoxCollider2D>().size = gameObject.GetComponent<BoxCollider2D>().size;
            MaskHasTaken();
        //    }
        }
          
    }   
    
      
    
    void MaskHasTaken()
    {
        // It will changed this function when the death animation is completed. 
        Destroy(gameObject);
    }

    void MaskHasBeenTaken(){
         
        maskTaken = true;
 
    }

    private IEnumerator MaskisTakening(float waitTime)
    {
        float counter = 0;

        while (counter < waitTime)
        {
            //Increment Timer until counter >= waitTime
            counter += Time.deltaTime;
            Debug.Log("We have waited for: " + counter + " seconds");
            if (quit)
            {
                //Quit function
                yield break;
            }
            //Wait for a frame so that Unity doesn't freeze
            yield return null;
        }
        
    }

}
