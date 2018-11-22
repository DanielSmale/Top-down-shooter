/*******************************************************
 * 
 * 
 * DestroyOnDie.cs
 * - Destroys the GameObject when the Die method is run
 * - we can call this from other Components when a condition is met, like if we run out of health
 * 
 * 
 * public variables: none
 * 
 * 
 * public custom methods
 * - Die
 *   - Calls the Destroy method to remove the GameObject from the scene
 *   - see link: https://docs.unity3d.com/ScriptReference/Object.Destroy.html
 * 
 * 
 *******************************************************/
using UnityEngine;


/*
 * The DestroyOnDie class inherits from Monobehaviour, which lets us add it as a component to a GameObject
 * see link: https://docs.unity3d.com/ScriptReference/MonoBehaviour.html
 */
public class DestroyOnDie : MonoBehaviour
{

    /*
     * Die
     * We call the Destroy method to remove our bullet GameObject from the scene
     * see link: https://docs.unity3d.com/ScriptReference/Object.Destroy.html
     */
    public void Die()
    {
        /*
         * DESTROY THE GAMEOBJECT
         * The Destroy method requires a GameObject to destroy.
         * We give it the GameObject this script is on (in the editor), which is "gameObject" - note the lower case "g"
         * see link: https://docs.unity3d.com/ScriptReference/Object.Destroy.html
         */
        Destroy(gameObject);
    }
}
