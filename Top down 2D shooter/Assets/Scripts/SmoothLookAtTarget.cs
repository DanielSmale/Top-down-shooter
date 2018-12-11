using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothLookAtTarget : MonoBehaviour
{
    public Transform target; //A reference to the transform component of the target
    public float smoothing = 5.0f;
    public float adjustmentAngle = 0.0f;
    

    private void Update()
    {
        if(target != null) //If there is a target
        {
            Vector3 difference = target.position - transform.position; 

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            Quaternion newRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));

            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * smoothing);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }


}
