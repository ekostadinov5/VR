﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
    private Rigidbody rb;
    private bool jump;
    private bool isGrounded;

    public int jumpSpeed;
    public float toggleAngle;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = false;
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.eulerAngles.x <= 360 - toggleAngle && Camera.main.transform.eulerAngles.x >= 360 - 90)
        {
            jump = true;
        }
        else
        {
            jump = false;
        }
        if (jump && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
