using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour {

    int playerSpeed;
    int jumpSpeed;

    Rigidbody rb;
    bool isGrounded;

    int clicked;
    float clickTime;
    float clickDelay;
    bool jumped;

    // Use this for initialization
    void Start()
    {
        playerSpeed = 11;
        jumpSpeed = 7;

        rb = GetComponent<Rigidbody>();
        isGrounded = false;

        clicked = 0;
        clickTime = 0F;
        clickDelay = 0.25F;
        jumped = false;
    }

    // Update is called once per frame
    void Update () {
        MoveOrJump();
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = true;
    }

    void MoveOrJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked++;
            jumped = false;
        }
        if (clicked > 0 && clicked < 3)
        {
            clickTime += Time.fixedDeltaTime;

            if (clickTime > clickDelay)
            {
                clicked = 0;
                clickTime = 0F;
            }

            if (clicked == 2)
            {
                if (clickTime <= clickDelay && !isGrounded)
                {
                    clicked = 0;
                    clickTime = 0F;
                    rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                    jumped = true;
                }
                else
                {
                    clicked = 0;
                    clickTime = 0F;
                }
            }
        }

        if (Input.GetMouseButton(0) && !jumped)
        {
            transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        }
    }
}
