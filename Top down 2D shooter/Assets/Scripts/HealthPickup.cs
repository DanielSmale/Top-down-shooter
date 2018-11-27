/**********************************************************
 * 
 * HealthPickup.cs
 * - adds health to the players HealthSystem component
 * 
 * 
 * private variables
 * - health
 *   - the amount of health to add
 *   
 *   
 * private methods
 * - OnTriggerEnter2D
 *   - uses the TakeDamage method on the player GameObject to add health
 *   - destroys the pickup GameObject after adding the health
 *   
 * 
 **********************************************************/

using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    /*
     * health
     * this is the amount of health to add
     * note that this is a private variable, as we wont be changing it in the inspector
     * note it is also a readonly variable meaning we cant change it while the game is running
     * see link: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly
     */
    private readonly int health = 10;


    /*
     * OnTriggerEnter2D
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerEnter2D.html
     * see link: https://docs.unity3d.com/ScriptReference/Collider2D.html
     * here is where the health is added to the player health system
     * this GameObject will destroy itself when the health is added
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
         * ADD HEALTH TO PLAYER HEALTHSYSTEM
         * we use the SendMessage method on the "other" parameter, this is the player GameObject our trigger is overlapping
         * see link: https://docs.unity3d.com/ScriptReference/Component.SendMessage.html
         * see link: https://docs.unity3d.com/ScriptReference/SendMessageOptions.html
         * we use the players TakeDamage method (on the players HealthSystem component) to add health
         * NOTE: we add health using minus health (?!??!) 
         *       this is because the TakeDamage method will remove the health, so we give it minus health to add instead!
         */
        other.transform.SendMessage("TakeDamage", -health, SendMessageOptions.DontRequireReceiver);


        /*
         * DESTROY THE PICKUP GAMEOBJECT
         * see link: https://docs.unity3d.com/ScriptReference/Object.Destroy.html
         * here we destroy the pcikup GameObject so the player can't pick it up again
         */
        Destroy(gameObject);
    }
}
