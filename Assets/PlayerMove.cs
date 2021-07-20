using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 10f;

    public float gravity = -9.81f;

    Vector3 velocity;

    public float jump_height = 4f;

    public Transform floor_check;
    public float floor_distance = 0.4f;
    public LayerMask floor_mask;
    bool is_in_floor;

    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        is_in_floor = Physics.CheckSphere(
            floor_check.position,
            floor_distance,
            floor_mask
        );

        Debug.Log(is_in_floor);

        if (is_in_floor && velocity.y < 0) {
            velocity.y = -2f;
        }

        // move forward, backward and sideways
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && is_in_floor) {
            velocity.y = Mathf.Sqrt(jump_height * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
