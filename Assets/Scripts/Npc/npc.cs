using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npc : MonoBehaviour
{
    #region public 
    public Transform leftLimit;
    public Transform rightLimit;

    [HideInInspector] public Transform target; // player, ontrigger2d
    public bool inRangePlayer = false;
    public bool moveMode = true;

    public GameObject triggerArea;

    public float moveSpeed;
    #endregion


    #region private
    Animator anim; // enemy anim
    #endregion
     
    private void Awake()
    {

        SelectTarget(); //to make sure eneymy always have a target to follaw;
        anim = GetComponent<Animator>();

    }
    private void Start()
    {
        moveMode = true;
    }

    void Update()
    {
        Move();

        if (!moveMode && inRangePlayer) { StopMove(); }

        if (target == null) {  SelectTarget(); }
        if (target != null && target.position.x == transform.position.x) { SelectTarget(); }
        

    }
  
    void StopMove()
    {
        anim.SetBool("walk", false);
       
    }


    /// <summary>
    /// when hotzone collider is not triggered, select a target from left or right.
    /// </summary>
    public void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight) { target = leftLimit; }
        else { target = rightLimit; }

        NpcFlipToLimit(); 

    }

    /// <summary>
    /// if hedefin x eksenindeki yeri, playerin x inden b�y�kse d�z dur, k���kse d�n
    /// </summary>
    public void NpcFlipToLimit()
    {
        Vector2 rotation = transform.eulerAngles;

        if (transform.position.x > target.position.x) { rotation.y = 180f; }
        else { rotation.y = 0f; }

        transform.eulerAngles = rotation;
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

}
