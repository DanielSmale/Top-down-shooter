/**********************************************************
 * 
 * AttackSpeed.cs
 * - increases the fire speed of the player weapon for a short time
 * 
 * 
 * private variables
 * - time
 *   - the total time the pickup is active in seconds
 * 
 * - speed
 *   - the new, faster speed we want to fire at
 *   
 * - oldSpeed
 *   - the original fire speed 
 *   - we will set the fire speed to this value when the time runs out
 * 
 *   
 * private methods
 * - Start
 *   - store the original speed in the "oldSpeed" variable
 *   - set the fireTime to the new, faster speed
 *   - start the timer using the Invoke method 
 *   
 * - TimeOut
 *   - reset the fireTime to the "oldSpeed" variable, setting our fire speed to normal
 * 
 **********************************************************/

using UnityEngine;

public class AttackSpeed : MonoBehaviour
{
    /*
     * time
     * the total time the pickup is active in seconds
     */
    private float time = 3;

    /*
     * speed
     * the new, faster speed we want to fire at
     */
    private float speed = 0.1f;

    /*
     * oldSpeed
     * the original fire speed, we will set the weapon back to this when the time runs out
     */
    private float oldSpeed;


    /*
     * Start
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
     * we set the "oldSpeed" variable to the weapon's current speed (fireTime)
     * we set the fireTime of the weapon to the "speed" variable
     * we use the Invoke method for a timer to call the "TimeOut" method on this class
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Invoke.html
     */
    void Start ()
    {
        /*
         * SET THE oldSpeed VALUE TO THE WEAPON'S fireTime
         * we set the value of "oldSpeed" to the weapon's "fireTime" property, so we can change it back later
         * NOTE: we use "Get Component In Children" to get the weapon from the player GameObject OR any child GameObjects
         *       this will be useful when you have many weapons you wish to switch between
         * see link: https://docs.unity3d.com/ScriptReference/GameObject.GetComponentInChildren.html
         */
        oldSpeed = transform.GetComponentInChildren<Weapon>().fireTime;

        /*
         * SET THE WEAPON'S fireTime VALUE TO speed
         * we set the weapon's "fireTime" property to the "speed" variable, to fire faster
         * NOTE: we use "Get Component In Children" to get the weapon from the player GameObject OR any child GameObjects
         *       this will be useful when you have many weapons you wish to switch between
         * see link: https://docs.unity3d.com/ScriptReference/GameObject.GetComponentInChildren.html
         */
        transform.GetComponentInChildren<Weapon>().fireTime = speed;

        /*
         * SET A TIMER TO SET THE WEAPON'S fireTime BACK AGAIN
         * set an Invoke timer to call the "TimeOut" method
         * TimeOut will swap the weapon's "fireTime" to the value of "oldSpeed"
         */
        Invoke("TimeOut", time);
    }

    /*
     * TimeOut
     * swaps the weapon's "fireTime" to the value of "oldSpeed"
     * we destroy this component using "this"
     * NOTE: we are NOT destroying the GameObject here! we are destroying this component (AttackSpeed)
     * see link: https://docs.unity3d.com/ScriptReference/Object.Destroy.html
     * this will remove the component from the player GameObject
     */
    void TimeOut()
    {
        /*
         * SET THE WEAPON'S fireTime TO THE VALUE OF oldSpeed
         * set the weapons fire speed back to the original value
         */ 
        transform.GetComponentInChildren<Weapon>().fireTime = oldSpeed;

        /*
         * DESTROY THIS COMPONENT
         * here we remove this component (AttackSpeed) from the player GameObject
         * NOTE: we use "this" in the Destroy method to destroy "this" component (AttackSpeed)
         */
        Destroy(this);
    }
}
