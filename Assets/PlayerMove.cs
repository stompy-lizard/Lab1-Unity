using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // The speed at which the player moves
    public float speed = 20f;

    // The speed at which the player rotates
    public float gravity = -9.81f;

    // The speed at which the player can jump
    Vector3 velocity;

    // The height of the jump
    public float jump_height = 4f;

    // object to check if the player is on the ground
    public Transform floor_check;

    // offset for the player's position
    public float floor_distance = 0.4f;

    // the floor object
    public LayerMask floor_mask;

    // The player object
    public CharacterController controller;


    // Update is called once per frame
    void Update()
    {
        // move forward, backward and sideways
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // obtain the current move vector of the player on the y plane.
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // jump if the player hits the space bar and is on the ground
        if(Input.GetButtonDown("Jump") && isGrounded()) {
            velocity.y = Mathf.Sqrt(jump_height * -2f * gravity);
        }

        // Update the vertical velocity
        velocity.y += gravity * Time.deltaTime;

        // move the player
        controller.Move(velocity * Time.deltaTime);
    }

    // Returns true if the player is on the ground
    private bool isGrounded () {
        bool is_in_floor =  Physics.CheckSphere(
            floor_check.position,
            floor_distance,
            floor_mask
        );
        return is_in_floor;
    }
}
