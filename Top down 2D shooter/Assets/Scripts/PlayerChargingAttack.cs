using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargingAttack : MonoBehaviour
{
    public float doubleTapWait;
    public float boostSpeed = 15;
    public float boostTime = 4;

    public Transform ram;

    bool doubleTap = false;
    bool isBoosting = false;

    Rigidbody2D body;
    Transform ColliderTransform;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        ChargeAttack();

    }



    private void ChargeAttack()
    {
        //https://forum.unity.com/threads/single-tap-double-tap-script.83794/




        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Time.time < doubleTapWait + .3f)
            {
                doubleTap = true;
            }
            doubleTapWait = Time.time;

        }

        if (doubleTap && !isBoosting)
        {
            Debug.Log("doubleTap");
            doubleTap = false;
            DoBoost();
        }


    }

    void DoBoost()
    {
        isBoosting = true;
        //body.AddForce(transform.up * boostSpeed);
        GetComponent<TopDownCharacterController2D>().forwardSpeed = 25;
        ram.gameObject.SetActive(true);
        Invoke("PostBoost", boostTime);
    }


    void PostBoost()
    {
        GetComponent<TopDownCharacterController2D>().forwardSpeed = 10;
        ram.gameObject.SetActive(false);
        isBoosting = false;
    }
}
