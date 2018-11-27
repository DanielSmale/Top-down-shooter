/**********************************************************
 * 
 * Pickup.cs
 * - a configurable class for any type of pickup
 * - select which type of pickup in the editor using the "pickupType" variable
 * 
 * 
 * public variables
 * - pickupType
 *   - determines the type of pickup used
 *   
 * - health
 *   - the amount of health to add - only used in the "health" pickup
 *   
 *   
 * private methods
 * - OnTriggerEnter2D
 *   - adds the pickup to the player according to the "pickupType" variable
 *   - destroys this GameObject after the pickup has been activated
 *   
 * 
 **********************************************************/

using UnityEngine;


/*
 * PickupType
 * an enum (enumerable) to select which pickup to use
 * this enum has a public variable, "pickupType" used in the Pickup class
 * we can use "pickupType" in a switch statement to choose between pickups in the editor
 * see link: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/enum
 */
public enum PickupType
{
    Health,
    Damage,
    Invincible,
    AttackSpeed,
    MoveSpeed
}

public class Pickup : MonoBehaviour
{
    /*
     * pickupType
     * this is from the "PickupType" enum above
     * "pickupType" is displayed as a dropdown in the editor
     * we can choose between types of pickups from it
     * see link: https://unity3d.com/learn/tutorials/topics/scripting/enumerations
     */
    public PickupType pickupType;

    /*
     * health
     * only used in the health pickup selection
     * the value is the amount of health to add to the player HealthSystem
     */ 
    public int health = 10;


    /*
     * OnTriggerEnter2D
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerEnter2D.html
     * we use a switch statement to choose which pickup to use
     * we destroy this GameObject to remove it from the scene
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
         * CHOOSE WHICH PICKUP TO USE
         * we use a switch statement to choose which pickup to use
         * the "pickupType" variable is the selection
         */ 
        switch (pickupType)
        {
            /*
             * HEALTH PICKUP
             * we use SendMessage to add health to the player
             * we use the players TakeDamage method (on the players HealthSystem component) to add health
             * NOTE: we add health using minus health (?!??!) 
             *       this is because the TakeDamage method will remove the health, so we give it minus health to add instead!
             */
            case PickupType.Health:
                other.transform.SendMessage("TakeDamage", -health, SendMessageOptions.DontRequireReceiver);
                break;

            /*
             * DAMAGE INCREASE
             * we use AddComponent to add the DamageIncrease component to the player GameObject
             * the DamageIncrease component will handle itself from there
             */ 
            case PickupType.Damage:
                other.gameObject.AddComponent<DamageIncrease>();
                break;

            /*
             * INVINCIBLE
             * we use AddComponent to add the Invincible component to the player GameObject
             * the Invincible component will handle itself from there
             */
            case PickupType.Invincible:
                other.gameObject.AddComponent<Invincible>();
                break;

            /*
             * ATTACK SPEED
             * we use AddComponent to add the AttackSpeed component to the player GameObject
             * the AttackSpeed component will handle itself from there
             */
            case PickupType.AttackSpeed:
                other.gameObject.AddComponent<AttackSpeed>();
                break;

            /*
             * SPEED BOOST
             * we use AddComponent to add the SpeedBooster component to the player GameObject
             * the SpeedBooster component will handle itself from there
             */
            case PickupType.MoveSpeed:
                other.gameObject.AddComponent<SpeedBooster>();
                break;

            default:
                break;
        }

        /*
         * DESTROY THE PICKUP GAMEOBJECT
         * see link: https://docs.unity3d.com/ScriptReference/Object.Destroy.html
         * here we destroy the pickup GameObject so the player can't pick it up again
         */
        Destroy(gameObject);
    }
}
