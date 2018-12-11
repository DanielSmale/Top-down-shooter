using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargingAttack : MonoBehaviour
{
    public float doubleTapWait;  //Wait time after double tap to prevent spamming
    public float boostSpeed = 15; 
    public float boostTime = 4; //How long the boost applies for

    public Transform ram; // The transform component of the 'ram' child on the player
    public Transform[] trail; // The trail child objects

    bool doubleTap = false;
    bool isBoosting = false; 
    //Whether or not the player has doubled tapped and is the player currently boosting

    Rigidbody2D body;
    Transform ColliderTransform;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();// Get a reference to the rigidbody component
    }

    void Update()
    {
        ChargeAttack(); //Once every frame, call the charge attack function
    }
        
    private void ChargeAttack()
    {
        //https://forum.unity.com/threads/single-tap-double-tap-script.83794/

        
        if (Input.GetKeyDown(KeyCode.W)) // If the w key is down
        {
            if (Time.time < doubleTapWait + .3f) // and if the time is less than double tap wait plus .3 seconds
            {
                doubleTap = true; // Make double tap true preventing us from spamming
            }
            doubleTapWait = Time.time; // Make the wait time longer 

        }

        if (doubleTap && !isBoosting) // if the player has double tapped and is not currently boosting
        {
            Debug.Log("doubleTap"); 
            doubleTap = false; // double tap is now equal to false
            DoBoost();
        }
    }

    void DoBoost()
    {
        isBoosting = true; 
        
        GetComponent<TopDownCharacterController2D>().forwardSpeed = 25; // increase the speed to 25
        ram.gameObject.SetActive(true); // Activate the ram to damage enemies
        for (int i = 0; i < trail.Length; i++)
        {
            trail[i].gameObject.SetActive(true);
        }
        Invoke("PostBoost", boostTime);
    }


    void PostBoost()
    {
        GetComponent<TopDownCharacterController2D>().forwardSpeed = 10; // Slow us down after our boost
        ram.gameObject.SetActive(false); // Stop damaging enemies
        for (int i = 0; i < trail.Length; i++)
        {
            trail[i].gameObject.SetActive(false);
        }
       
        isBoosting = false; 
    }
}
