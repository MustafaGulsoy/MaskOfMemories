using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourch : MonoBehaviour
{
    bool tourchOpen = false;
    public GameObject enemy;

    void Start()
    {
    }
    void Update()
    {
        ToggleTorch();
    }

    void ToggleTorch()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            tourchOpen = !tourchOpen;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.transform.parent.gameObject.name != "Enemies")
            {
                enemy = collision.transform.parent.gameObject;

                if (tourchOpen) { enemy.GetComponent<SpriteRenderer>().enabled = true; }
                else { enemy.GetComponent<SpriteRenderer>().enabled = false; }
            }
            else
            {

                if (tourchOpen) { collision.gameObject.GetComponent<SpriteRenderer>().enabled = true; }
                else { collision.gameObject.GetComponent<SpriteRenderer>().enabled = false; }
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && collision.transform.parent.gameObject.name != "Enemies")
        {

        }


        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.transform.parent.gameObject.name != "Enemies")
            {
                enemy = collision.transform.parent.gameObject;

                enemy.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;


            }
        }
    }
}
