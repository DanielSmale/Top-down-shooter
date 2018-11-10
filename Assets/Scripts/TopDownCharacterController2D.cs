using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour {
    public float forwardSpeed = 30;
    public float backwardSpeed = 6;
    public float turningSpeed = 120;


    [Range(0, 1)]
    public float drift = 1f;
    public float maxGripSpeed = 3f;


    Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");
        float driftAmount = 1;


        if (RightVelocity().magnitude > maxGripSpeed)
        {
            driftAmount = drift;
        }
        body.velocity = ForwardVelocity() + RightVelocity() * driftAmount;

        if (forwardInput > 0)
            body.AddForce(transform.up * forwardSpeed * forwardInput);

        if (forwardInput < 0)
            body.AddForce(transform.up * backwardSpeed * forwardInput);


        float turnForce = Mathf.Lerp(0, -turningSpeed, body.velocity.magnitude * 0.5f);
        body.angularVelocity = turnInput * turnForce;

    }
    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(body.velocity, transform.up);
    }
    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(body.velocity, transform.right);
    }
    //old game code
    //public float speed = 5.0f;
    //Rigidbody2D rigidbody2D;
    //void Start()
    //{
    //    rigidbody2D = GetComponent<Rigidbody2D>();
    //    }
    //void FixedUpdate()
    //{
    //    float x = Input.GetAxis("Horizontal");
    //    float y = Input.GetAxis("Vertical");
    //    rigidbody2D.velocity = new Vector2(x, y) * speed;
    //    rigidbody2D.angularVelocity = 0.0f;
    //}
}
