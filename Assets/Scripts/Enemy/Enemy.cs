using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Public
    public float attackDistance; // minimum distance for attack
    public float timer; // for cooldown, wait for another atack, it is defined by users, we can change it on unity panel

    public Transform leftLimit;
    public Transform rightLimit;

    [HideInInspector] public Transform target; // player, ontrigger2d
    [HideInInspector] public bool inRangeTarget; // check player in range distance
    [HideInInspector] public bool attackMode; // attack
    [HideInInspector] public bool gethitMode = true; 

    public GameObject hotZone;
    public GameObject triggerArea;

    public float moveSpeed;
    public float atackPower =10 ;
    public float enemyHealth = 100f;
    #endregion

    #region private
    Animator anim; // enemy anim
    float distance; // store distance enemy-target
    public bool cooling; // check enemy is cooling after attack
    float intTimer; // wait time is stored after attack, used to reuse
    #endregion



    private void Awake()
    { 
        
        SelectTarget(); //to make sure eneymy always have a target to follaw;
        intTimer = timer; // store initial vlaue timer
        anim = GetComponent<Animator>(); 
       
    }

    void Update()
    {
        if (!attackMode)
        {
            Move();
        }
        if (inRangeTarget)
        {
            enemyAction();
        }

        // if there is no player or like that, select place
        if (!InsideOfLimits() && !inRangeTarget && !anim.GetCurrentAnimatorStateInfo(0).IsName("atack_enermy_cultist_priest"))
        {
           
            if (target == null)
            {
                SelectTarget();
            }
            if(target != null && target.position.x == transform.position.x)
            {
                SelectTarget();
            }
            
        }



    }

    bool InsideOfLimits()
    {

        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    /// <summary>
    /// when hotzone collider is not triggered, select a target from left or right.
    /// </summary>
    public void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight){ target = leftLimit; }
        else { target = rightLimit; }

        Flip();

    }

    /// <summary>
    /// if hedefin x eksenindeki yeri, playerin x inden b�y�kse d�z dur, k���kse d�n
    /// </summary>
    public void Flip()
    {
        Vector2 rotation = transform.eulerAngles;
        
        if (transform.position.x > target.position.x){ rotation.y = 180f; }
        else { rotation.y = 0f; }

        transform.eulerAngles = rotation;
    }

    void enemyAction()
    {
        distance = Vector2.Distance(transform.position, target.position);
        
        if(distance > attackDistance) { StopAttack(); }
        else if(distance <= attackDistance && cooling == false) { Attack();}

        //  enemy atack to player, after that, wait timer
        if (cooling) { 

            anim.SetBool("attack", false);
            CoolDown(); 

        }
    }

    /// <summary>
    /// we wait to attack again
    /// </summary>
    void CoolDown()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void Attack()
    {
        timer = intTimer; // reset time when player enter attack range
        attackMode = true;

        anim.SetBool("walk", false);
        anim.SetBool("attack", true);
 
    }

    public void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("attack", false);
    }

    // move to player
    void Move()
    {
        anim.SetBool("walk", true);

        // to be sure, there is no attack anim, 
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("atack_enermy_cultist_priest") && !anim.GetCurrentAnimatorStateInfo(0).IsName("idle_enermy_cultist_priest"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        }
    
    }


    /// <summary>
    ///  under here, they will be executed by animation
    /// </summary>

    // when atack is happened, by animation atack, it is triggered.
    public void TriggerCooling()
    {
        cooling = true;
    }
    // stop hit anim from anim,( to avoid ienumator waiting anim)
    public void GetHitStopAnim()
    {
        anim.SetBool("gethit", false);
    }
    public void DieStopAnim()
    {
        anim.SetBool("die", true);
        // delete everything 
        Destroy(gameObject.GetComponent<Enemy>());
        transform.tag = "Enemy";
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
   

}
