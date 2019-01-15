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


    Transform ColliderTransform;

    void Update()
    {
        ChargeAttack(); //Once every frame, call the charge attack function
    }
        
    private void ChargeAttack()
    {

        
        if (Input.GetKeyDown(KeyCode.W)) // If the w key is down
        {
            if (Time.time < doubleTapWait + 0.3f) // and if the time is less than double tap wait plus .3 seconds
            {
                doubleTap = true; // Make double tap true for a limited time preventing us from spamming
            }
            doubleTapWait = Time.time; // Reset the double tap wait

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
        Invoke("PostBoost", boostTime); //call postboost when the boost time is up
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
