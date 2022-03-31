using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    Rigidbody2D rb2D;
    Camera mainCamera;
    Vector2 lookDirection;

    private Animator animator;  
    private GameObject NpcObject;
    public GameObject bullet;
    public List<GameObject> NpcLists = new List<GameObject>();
    public Transform firePoint;
    public Transform pistol;


    public float health = 100f;
    public float speed = 10.0F;
    public float jumpspeed = 10.0F;
    public float bulletSpeed = 50f;

    float changeDimY = 59f;
    float distanceBetweenNpc;
    float lookAngle;

    public bool grounded = true;
    private bool npcInRange = false;
    bool untouchable;
    bool speaking = false;

    private int j = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        untouchable = false;
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame 
    void Update()
    {
        ChangeDimension();
    }
    private void FixedUpdate() 
    {
        CameraFollowPlayer(); 
        Dialogue();
    }

    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Move()
    {

        
        bool s = Input.GetKey(KeyCode.S);
        bool w = Input.GetKey(KeyCode.W);
        bool space = Input.GetKey(KeyCode.Space);
        if (s) { rb2D.gravityScale = 10; }
        else { rb2D.gravityScale = 1; }

        float run = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        
    
        if(run > 0)
        {   
            animator.SetBool("walk",true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if(run < 0)
        {
            animator.SetBool("walk",true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
          if(run == 0){
            animator.SetBool("walk",false);
        }

    
        if ((w || space) && grounded)
        {
            grounded = false;
            animator.SetTrigger("jump");
            rb2D.AddForce(transform.up * jumpspeed, ForceMode2D.Impulse);
        }
        
        if(grounded){ animator.SetBool("grounded", true); }
        if(untouchable){ animator.SetBool("gun", true); }
        else { animator.SetBool("gun", false);}

        transform.Translate(run, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.transform.tag == "Floor") { grounded = true; animator.SetBool("grounded", true); }

    }
    void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.transform.tag == "Floor") { grounded = false; animator.SetBool("grounded", false);}


    }

    void ChangeDimension()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (untouchable)
            {
                untouchable = !untouchable;

                gameObject.transform.Translate(0, -changeDimY, 0);
                mainCamera.transform.Translate(0, -changeDimY, 0);
            }
            else
            {
                untouchable = !untouchable;
                gameObject.transform.Translate(0, changeDimY, 0);
                mainCamera.transform.Translate(0, changeDimY, 0);
            }
        }
    }

    void Dialogue()
    {
       
        if (NpcObject != null)
        { 
            if (NpcObject.gameObject.GetComponent<NpcController>().moveMode) { Move(); }
        }
        else { Move(); }

        interaction();

    }
      private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Npc"))
        {
            collision.gameObject.GetComponent<NpcController>().inRangePlayer = true;

            //1
            npcInRange = collision.gameObject.GetComponent<NpcController>().inRangePlayer;
            
             
       
            if( !NpcLists.Contains(collision.gameObject)) { NpcLists.Add(collision.gameObject); }
     
            
        }
     

    }

   private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Npc"))
        {
            collision.gameObject.GetComponent<NpcController>().inRangePlayer = false;

            //1
            npcInRange = collision.gameObject.GetComponent<NpcController>().inRangePlayer;
            NpcLists.Remove(collision.gameObject);

        }

    }
    public void interaction()
    {

        if (Input.GetKeyDown(KeyCode.E) && npcInRange && !speaking)
        {
            speaking = true;


            distanceBetweenNpc = transform.position.x - NpcLists[0].transform.position.x;

            for (int i = 0; i < NpcLists.Count; i++)
            {

                if (distanceBetweenNpc < transform.position.x - (NpcLists[i]).transform.position.x)
                {
                    distanceBetweenNpc = transform.position.x - (NpcLists[i]).transform.position.x;
                    j = i;
                }

            }
            NpcObject = NpcLists[j].gameObject;

            if (NpcLists.Count == 1)
            {
                NpcObject = NpcLists[0].gameObject;
            }

            NpcObject.gameObject.GetComponent<NpcController>().moveMode = false;
            Vector2 rotation = NpcObject.gameObject.GetComponent<NpcController>().transform.eulerAngles;

            if (gameObject.transform.position.x > NpcObject.gameObject.GetComponent<NpcController>().transform.position.x) { rotation.y = 0f; }
            else { rotation.y = 180f; }

            NpcObject.gameObject.GetComponent<NpcController>().transform.eulerAngles = rotation;
            NpcObject.gameObject.GetComponent<NpcController>().inRangePlayer = true;
        }

        if (Input.GetKeyDown(KeyCode.Q) && npcInRange && speaking)
        {
            speaking = false;

            NpcObject.gameObject.GetComponent<NpcController>().NpcFlipToLimit();
            NpcObject.gameObject.GetComponent<NpcController>().moveMode = true;

            NpcObject = null;
        }
    }

    void CameraFollowPlayer()
    {
        if (mainCamera.transform.position.x != gameObject.transform.position.x)
        {
            mainCamera.transform.Translate((gameObject.transform.position.x - mainCamera.transform.position.x) * 1/10,1f + (gameObject.transform.position.y - mainCamera.transform.position.y) * 4/10, 0);
        }
    }
  

}
