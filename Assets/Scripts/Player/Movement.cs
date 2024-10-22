using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    public Timer timer;
    private Animator character;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Processing Inputs
        if (timer.isTimerOn) ProcessInputs();
        //moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        //Physics Calculations
        if (timer.isTimerOn)
        {
            Move();
            Debug.Log(moveDirection);
        }
        else
        {
            rb.velocity = new Vector2(0,0);
        }
        //rb.velocity = moveDirection * movementSpeed;
    }
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX != 0)
        {
            moveY = 0;
        }
        if (moveY != 0)
        {
            moveX = 0;
        }
        moveDirection = new Vector2(moveX, moveY).normalized;
        if (moveX == 1)
        {
            character.SetTrigger("isMovingRight");
            character.ResetTrigger("isMovingLeft");
            character.ResetTrigger("isMovingDown");
            character.ResetTrigger("isMovingUp");
        }
        if (moveX == -1)
        {
            character.SetTrigger("isMovingLeft");
            character.ResetTrigger("isMovingRight");
            character.ResetTrigger("isMovingDown");
            character.ResetTrigger("isMovingUp");
        }
        if (moveY == 1)
        {
            character.SetTrigger("isMovingUp");
            character.ResetTrigger("isMovingDown");
            character.ResetTrigger("isMovingRight");
            character.ResetTrigger("isMovingLeft");
        }
        if (moveY == -1)
        {
            character.SetTrigger("isMovingDown");
            character.ResetTrigger("isMovingUp");
            character.ResetTrigger("isMovingRight");
            character.ResetTrigger("isMovingLeft");
        }
    }

    private void Move()
    {
        
        rb.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }
}
