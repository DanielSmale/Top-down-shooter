/**********************************************************
 * 
 * Invincible.cs
 * - deactivates the collider for a short time to stop the player taking damage
 * 
 * 
 * private variables
 * - time
 *   - the total time the pickup is active in seconds
 * 
 *   
 * private methods
 * - Start
 *   - deactivate the collider
 *   - start the timer using the Invoke method
 *   
 * - TimeOut
 *   - re-activate the collider
 * 
 **********************************************************/

using UnityEngine;

public class Invincible : MonoBehaviour
{
    /*
     * time
     * the total time the pickup is active in seconds
     */
    private float time = 5;


    /*
     * Start
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
     * we deactivate the colldier to stop taking damage
     * we use the Invoke method for a timer to call the "TimeOut" method on this class
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Invoke.html
     */
    void Start ()
    {
        /*
         * DEACTIVATE THE COLLIDER
         * we set our collider's "eanbled" peroperty to false - this stop the collider from interacting with other colliders
         * see link: https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html
         */
        transform.GetComponent<Collider2D>().enabled = false;

        /*
         * SET A TIMER TO ACTIVATE THE COLLIDER AGAIN
         * set an Invoke timer to call the "TimeOut" method
         * TimeOut activate the collider again
         */
        Invoke("TimeOut", time);
    }


    /*
     * TimeOut
     * we activate the collider again to start recieving damage
     * we destroy this component using "this"
     * NOTE: we are NOT destroying the GameObject here! we are destroying this component (Invincible)
     * see link: https://docs.unity3d.com/ScriptReference/Object.Destroy.html
     * this will remove the component from the player GameObject
     */
    void TimeOut()
    {
        /*
         * RE-ACTIVATE THE COLLIDER
         * we set our collider's "eanbled" peroperty to true - this allow the collider to interact with other colliders again
         * see link: https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html
         */
        transform.GetComponent<Collider2D>().enabled = true;

        /*
         * DESTROY THIS COMPONENT
         * here we remove this component (Invincible) from the player GameObject
         * NOTE: we use "this" in the Destroy method to destroy "this" component (Invincible)
         */
        Destroy(this);
    }
}
