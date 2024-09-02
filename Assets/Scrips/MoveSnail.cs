using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSnail : MonoBehaviour
{
    
    Rigidbody2D rb;
    public GameObject snail;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = Random.Range(1,3);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;

        }
    }

    // Update is called once per frame
    void Update()
    {
        snail.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1,-5), 0);
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
}
