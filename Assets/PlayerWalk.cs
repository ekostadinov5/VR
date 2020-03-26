using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour {
    private Rigidbody rb;
    private bool moveForward;

    public int playerSpeed;
    public float toggleAngle;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveForward = false;
    }

    // Update is called once per frame
    void Update() {
        if (Camera.main.transform.eulerAngles.x >= toggleAngle && Camera.main.transform.eulerAngles.x <= 90F)
        {
            moveForward = true;
        }
        else
        {
            moveForward = false;
        }
        if (moveForward)
        {
            Vector3 forward = Camera.main.transform.forward;
            forward = forward.normalized * playerSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + forward);
        }
    }
}
