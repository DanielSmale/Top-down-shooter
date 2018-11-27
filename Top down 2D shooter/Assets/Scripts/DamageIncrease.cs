/**********************************************************
 * 
 * DamageIncrease.cs
 * - temporarily swaps the bullet prefab on the player weapon for a higher damage bullet
 * 
 * 
 * private variables
 * - time
 *   - the total time the pickup is active in seconds
 * 
 * - oldPrefab
 *   - the original bullet prefab
 *   - this will be used to replace the current bullet prefab when the pickup deactivates
 * 
 *   
 * private methods
 * - Start
 *   - store the old bullet prefab
 *   - load the high damage bullet prefab into the players weapon
 *   - we load the high damage bullet from the Project folder using "Resources.Load".
 *   - Resources.Load will load a prefab (or other file) from the "Resources" folder at runtime
 *   - see link: https://docs.unity3d.com/ScriptReference/Resources.Load.html
 *   - start the timer using the Invoke method
 *   
 * - TimeOut
 *   - runs when the timer expires
 *   - swaps the player weapon's bullet prefab for the original, lower damage one
 *   - destroys this component, removing it from the player GameObject
 * 
 **********************************************************/
using UnityEngine;

public class DamageIncrease : MonoBehaviour
{
    /*
     * time
     * the total time the pickup is active in seconds
     */
    private float time = 5;

    /*
     * oldPrefab
     * stores the original bullet prefab on the player weapon
     */ 
    private GameObject oldPrefab;


    /*
     * Start
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
     * we save the original bullet prefab from the player weapon to "oldPrefab"
     * we then swap the player weapon's bullet for the high damage one
     * see link: https://docs.unity3d.com/ScriptReference/Resources.Load.html
     * lastly, we use the Invoke method for a timer to call the "TimeOut" method on this class
     * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Invoke.html
     */
    void Start()
    {
        /*
         * GET THE CURRENT BULLET PREFAB FROM THE PLAYER WEAPON
         * we store the current bullet prefab in "oldPrefab", so we can swap it back later
         * NOTE: we use "Get Component In Children" to get the weapon from the player GameObject OR any child GameObjects
         *       this will be useful when you have many weapons you wish to switch between
         * see link: https://docs.unity3d.com/ScriptReference/GameObject.GetComponentInChildren.html
         */
        oldPrefab = transform.GetComponentInChildren<Weapon>().bulletPrefab;

        /*
         * LOAD THE HIGH DAMAGE BULLET PREFAB AND PUT IT INTO THE PLAYER WEAPON
         * we use "Resources.Load" to get the high power bullet
         * see link: https://docs.unity3d.com/ScriptReference/Resources.Load.html
         * we put that bullet into the player weapon's "bulletPrefab" variable so
         * next time we fire the weapon, we should get a high damage bullet
         * NOTE: we use "Get Component In Children" to get the weapon from the player GameObject OR any child GameObjects
         *       this will be useful when you have many weapons you wish to switch between
         * see link: https://docs.unity3d.com/ScriptReference/GameObject.GetComponentInChildren.html
         */
        transform.GetComponentInChildren<Weapon>().bulletPrefab = Resources.Load("Bullet Damage Increase") as GameObject;

        /*
         * SET A TIMER TO SWAP BULLETS BACK AGAIN
         * set an Invoke timer to call the "TimeOut" method
         * TimeOut will swap the high damage bullet for the original bullet
         */ 
        Invoke("TimeOut", time);
    }


    /*
     * TimeOut
     * swaps the high damage bullet back for the original bullet stored in the "oldPrefab" variable
     * we destroy this component using "this"
     * NOTE: we are NOT destroying the GameObject here! we are destroying this component (DamageIncrease)
     * see link: https://docs.unity3d.com/ScriptReference/Object.Destroy.html
     * this will remove the component from the player GameObject
     */
    void TimeOut()
    {
        /*
         * SWAP THE PLAYER WEAPON BULLET FOR THE ORIGINAL
         * we set the player weapon bullet to the "oldPrefab" which is its original bullet prefab
         * NOTE: we use "Get Component In Children" to get the weapon from the player GameObject OR any child GameObjects
         *       this will be useful when you have many weapons you wish to switch between
         * see link: https://docs.unity3d.com/ScriptReference/GameObject.GetComponentInChildren.html
         */
        transform.GetComponentInChildren<Weapon>().bulletPrefab = oldPrefab;

        /*
         * DESTROY THIS COMPONENT
         * here we remove this component (DamageIncrease) from the player GameObject
         * NOTE: we use "this" in the Destroy method to destroy "this" component (DamageIncrease)
         */ 
        Destroy(this);
    }
}
