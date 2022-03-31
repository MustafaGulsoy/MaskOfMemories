using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = collision.transform.parent.gameObject; 
            Debug.Log(enemy.GetComponent<Enemy>().enemyHealth);
            enemy.GetComponent<Enemy>().enemyHealth -= 33;
            Debug.Log("1");
            enemy.gameObject.GetComponent<Animator>().SetBool("gethit", true);
            if(enemy.GetComponent<Enemy>().enemyHealth <= 0)
            {
                
                enemy.GetComponent<Animator>().SetBool("die", true);
            }
            Destroy(gameObject);
        }
    }
}
