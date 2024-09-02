using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Enemies : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject snail;
    public float moveSpeed = 5f;
    
     

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    // Update is called once per frame
    void Update()
    {
       

    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5,10));

            for (int i = 0; i < 1; i++)
            {
                
                Vector2 ePos = new Vector2(transform.position.x  , transform.position.y);
                
                Instantiate(snail, ePos, Quaternion.identity);
    
            }
            
        }
    }
    
   
}