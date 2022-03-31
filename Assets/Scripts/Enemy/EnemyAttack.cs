using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
  
  private void OnTriggerEnter2D(Collider2D collition) {
      if(transform.parent.gameObject.GetComponent<Enemy>().attackMode == true)
      {
          Debug.Log("dsdf");
          transform.parent.gameObject.GetComponent<Enemy>().attackMode = false;
          collition.gameObject.GetComponent<PlayerController>().health -= 10;
      }
  }
}
