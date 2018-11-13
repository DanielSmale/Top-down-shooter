/**********************************************************
 * 
 * HurtTrigger.cs
 * - damages things that com into contact with it
 * - has a timer that disables the collider when triggered, then re-enables it after a short time
 * 
 * 
 * public variables
 * - damage
 *   - the amount of damage this hurt trigger will do
 *   
 * - resetTime
 *   - the time between enabling the trigger
 *   
 *   
 * private custom methods
 * - ResetTrigger
 *   - enables the collider, ready to do damage again
 *   
 *   
 **********************************************************/

using UnityEngine;

public class HurtTrigger : MonoBehaviour
{
    /*
     * damage
     * the amount of damage to do to the other GameObject
     */ 
    public int damage;

    /*
     * resetTime
     * the time between resetting the collider
     */ 
    public float resetTime = 0.25f;

    /*
     * Start
     * this method is provided by Monobehaviour that only runs EVERY TIME a gameobject overlaps the collider
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerEnter.html
     * we will use this to damage the other gameobject if they have a TakeDamage method     
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
         * SEND THE DAMAGE TO THE OTHER GAMEOBJECT
         * Just like the Bullet, we send the damage to the other GameObject (collision)
         * if the other GameObject has a TakeDamage method, it will run that method
         */ 
        collision.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);

        /*
         * DISABLE THE COLLIDER
         * here we disable our collider for a short time
         * when it is enabled again, it will apply damage again!
         */ 
        GetComponent<Collider2D>().enabled = false;

        /*
         * ADD A TIMER TO RESET THE COLLIDER AFTER A SHORT TIME
         * here we use Invoke to reset our collider after a short time (resetTime)
         * this will set up our OnTriggerEnter method to run again
         */
        Invoke("ResetTrigger", resetTime);
    }


    /*
     * ResetTrigger
     * enables the collider, ready to deal more damage
     */ 
    private void ResetTrigger()
    {
        /*
         * ENABLE THE COLLIDER
         * we set the collider's enables property to true to enable it again
         */ 
        GetComponent<Collider2D>().enabled = true;
    }
}
