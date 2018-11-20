using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargingAttack : MonoBehaviour
{
    float doubleTapWait;
    GameObject transform;
    
    void Start()
    {
        transform = GetComponent<transform>;
    }

   void Update()
    {
        bool doubleTap = false;

        if (Input.GetKeyDown(KeyCode.W))
        {
            
        }
        
            
    }
	
}
