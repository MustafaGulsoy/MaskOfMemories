using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotZoneCheck : MonoBehaviour
{
    // Start is called before the first frame update
    Enemy enemyParent;
    bool inRange;
    Animator anim;

    void Start()
    {
        enemyParent = GetComponentInParent<Enemy>();
        anim = GetComponentInParent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("atack_enermy_cultist_priest"))
        {
            enemyParent.Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            enemyParent.moveSpeed *= 2;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            enemyParent.moveSpeed /= 2;
            enemyParent.target = null;
            inRange = false;
            gameObject.SetActive(false);
            enemyParent.triggerArea.SetActive(true);
            enemyParent.inRangeTarget = false;
            enemyParent.SelectTarget();
            
        }
    }
}
