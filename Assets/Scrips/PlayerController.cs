using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] InputAction move;
    [SerializeField] InputAction shoot;
    [SerializeField] float speed;
    [SerializeField] float moveDirection;
    public GameObject bullet;
    private bool isPlayerMoving;
    private bool shooting;
    private Coroutine iShot;
    private int lives = 3;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput.currentActionMap.Enable();
        move = playerInput.currentActionMap.FindAction("Move");
        shoot = playerInput.currentActionMap.FindAction("Shooting");
        speed = 5;
        isPlayerMoving = false;
        move.started += Move_started;
        move.canceled += Move_canceled;
        shoot.started += Shoot_started;
        shoot.canceled += Shoot_canceled;
    }

    private void Shoot_canceled(InputAction.CallbackContext obj)
    {
        StopAllCoroutines();
    }

    private void Shoot_started(InputAction.CallbackContext obj)
    {
        StartCoroutine(Shoot());
    }


    private void Move_canceled(InputAction.CallbackContext obj)
    {
        isPlayerMoving = false;
    }

    private void Move_started(InputAction.CallbackContext obj)
    {
        isPlayerMoving = true;
    }

    private void FixedUpdate()
    {
        if (isPlayerMoving)
        {
            rb.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed * moveDirection);
        }
        else
        {
            rb.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<float>();
        if(lives == 0)
        {
            DestroyObject(gameObject);
        }
    }

    IEnumerator Shoot()
    {
        for (int i = 0; i < 10000; i++)
        {
            //AudioSource.PlayClipAtPoint(playerShoot, transform.position);
            Vector2 bulletpos = new Vector2(transform.position.x + .8f, transform.position.y);

            Instantiate(bullet, bulletpos, Quaternion.identity);
            iShot = null;
            yield return new WaitForSeconds(.5f);
        }
        
    }
    public void losealife()
    {
        lives -= 1;
    }
}