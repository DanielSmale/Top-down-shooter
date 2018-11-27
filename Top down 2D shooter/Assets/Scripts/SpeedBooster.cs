/**********************************************************
 * 
 * SpeedBooster.cs
 * - increases the move speed of the player for a short time
 * 
 * 
 * private variables
 * - time
 *   - the total time the pickup is active in seconds
 * 
 * - speedIncrease
 *   - the amount we want to increase movement speed by
 *   - current speed + speed increase
 * 
 * - oldSpeed
 *   - the original move speed 
 *   - we will set the move speed to this value when the time runs out
 * 
 *   
 * private methods
 * - Start
 *   - store the original speed in the "oldSpeed" variable
 *   - add the speedIncrease to the current speed
 *   - start the timer using the Invoke method 
 *   
 * - TimeOut
 *   - reset the speed to the "oldSpeed" variable, setting our move speed to normal
 * 
 **********************************************************/

using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    /*
     * time
     * the total time the pickup is active in seconds
     */
    private float time = 3;

    /*
     * speedIncrease
     * the amount to increase the move speed by
     */
    private float speedIncrease = 5;

    /*
     * oldSpeed
     * the original move speed, we will set the player move speed back to this when the time runs out
     */
    private float oldSpeed;


    /*
     * Start
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
     * we set the "oldSpeed" variable to the player's current move speed (speed)
     * we add the speedIncrease to the player's "speed" property
     * we use the Invoke method for a timer to call the "TimeOut" method on this class
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Invoke.html
     */
    void Start ()
    {
        /*
         * SET THE oldSpeed VALUE TO THE "TOP DOWN CHARACTER CONTROLLER" speed
         * we set the value of "oldSpeed" to the player's "speed" property, so we can change it back later
         * we access the player's move speed from the Top Down Character Controller 2D component in the player GameObject
         */
        oldSpeed = transform.GetComponent<TopDownCharacterController2D>().forwardSpeed;

        /*
         * ADD speedIncrease TO THE TOP DOWN CHARACTER CONTROLLER speed
         * we add our speedIncrease variable to the current player move speed
         */ 
        transform.GetComponent<TopDownCharacterController2D>().forwardSpeed += speedIncrease;

        /*
         * SET A TIMER TO SET THE TOP DOWN CHARACTER CONTROLLER'S speed BACK AGAIN
         * set an Invoke timer to call the "TimeOut" method
         * TimeOut will swap the top down character controller's "speed" to the value of "oldSpeed"
         */
        Invoke("TimeOut", time);
	}


    /*
     * TimeOut
     * swaps the top down character controller's "speed" to the value of "oldSpeed"
     * we destroy this component using "this"
     * NOTE: we are NOT destroying the GameObject here! we are destroying this component (SpeedBooster)
     * see link: https://docs.unity3d.com/ScriptReference/Object.Destroy.html
     * this will remove the component from the player GameObject
     */
    void TimeOut()
    {
        /*
         * SET THE TOP DOWN CHARACTER CONTROLLER'S speed TO THE VALUE OF oldSpeed
         * set the top down character controller's speed back to the original value
         */
        transform.GetComponent<TopDownCharacterController2D>().forwardSpeed = oldSpeed;

        /*
         * DESTROY THIS COMPONENT
         * here we remove this component (SpeedBooster) from the player GameObject
         * NOTE: we use "this" in the Destroy method to destroy "this" component (SpeedBooster)
         */
        Destroy(this);
    }
}
