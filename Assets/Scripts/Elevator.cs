using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public bool goingUp;
    public float x;
    public float y;
    public Transform playerTranform;
    public float timer;

    private void Start() {
        Debug.Log(playerTranform);
    }
    private void Update()
    {

        changeFloor();
    }

    private void changeFloor(){
        
        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E) && timer <= 0)
        {
            timer = 1;
            timer -= Time.deltaTime;
            if( (Mathf.Abs(transform.position.x - playerTranform.position.x) < 1.5  ) && ( Mathf.Abs(transform.position.y - playerTranform.position.y) < 2))
            {
           
                Debug.Log(goingUp);
                Vector2 objVector = playerTranform.position;
                  if(goingUp) { playerTranform.position = new Vector2(objVector.x + x, objVector.y + y); }
                else {
                    playerTranform.position = new Vector2(objVector.x - x, objVector.y - y); 
                }
            }
        }
    }
}
