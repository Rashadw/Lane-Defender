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
    [SerializeField] float speed;
    [SerializeField] float moveDirection;
    private bool isPlayerMoving;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput.currentActionMap.Enable();
        move = playerInput.currentActionMap.FindAction("Move");
        speed = 5;
        isPlayerMoving = false;
        move.started += Move_started;
        move.canceled += Move_canceled;
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
        
    }
}
