using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MoveSnail : MonoBehaviour
{
    
    Rigidbody2D rb;
    public GameObject snail;
    public int health;
    private PlayerController playerController;
    public AudioClip hit;
    public AudioClip dead;

    // Start is called before the first frame update
    void Start()
    {
        health = Random.Range(1,3);
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            AudioSource.PlayClipAtPoint(hit, transform.position);
            health -= 1;

        }
        if (collision.gameObject.tag == "Finish")
        {
            playerController.LoseALife();
            DestroyObject(gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        snail.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1,-5), 0);
        if(health == 0)
        {
            AudioSource.PlayClipAtPoint(dead, transform.position);
            playerController.UpdateScore();
            Destroy(gameObject);
        }
    }
}
