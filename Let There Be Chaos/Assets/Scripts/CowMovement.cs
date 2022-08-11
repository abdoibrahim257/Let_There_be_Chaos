using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMovement : MonoBehaviour
{
    public Camera sceneCamera;
    public float speed = 0f;
    private float SPEED_CHANGE_AMOUNT = 120f;
    private float MIN_SPEED = 50f;
    private float MAX_SPEED = 550f;
    public Rigidbody2D rigidBody;
    private Vector2 moveDirection, mousePosition;
    // Weapon curWeapon;
    
    //public Weapon weapon;
    

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized; //to get input from one vector only 
        //to get mouse position
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        //Switching with gun cntroller
        
        // Changing player speed
        if (Input.GetKeyDown(KeyCode.H))    // Decrease Speed
        {
            speed -= SPEED_CHANGE_AMOUNT;
            if (speed < MIN_SPEED)
            {
                speed = MIN_SPEED;
            }
        }
        else if (Input.GetKeyDown(KeyCode.J))    // Resets speed
        {
            speed = 50f;
        }
        else if (Input.GetKeyDown(KeyCode.K))    // Increase Speed
        {
            speed += SPEED_CHANGE_AMOUNT;
            if (speed > MAX_SPEED)
            {
                speed = MAX_SPEED;
            }
        }
    }
    void move()
    {
        rigidBody.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);

        //to rotate the player according to mouse position
        Vector2 aimDirection = mousePosition - rigidBody.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        rigidBody.rotation = aimAngle;
    }
}
