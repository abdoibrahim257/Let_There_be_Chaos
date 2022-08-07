using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMovement : MonoBehaviour
{
    public Camera sceneCamera;
    public float speed = 0f;
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
        // if(Input.GetMouseButtonDown(0))
        // {
        //     curWeapon.Shoot();
        // }
        // else if(Input.GetMouseButtonUp(0))
        // {
        //     curWeapon.DontShoot();
        // }
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