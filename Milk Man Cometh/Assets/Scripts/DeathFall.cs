using UnityEngine;
using System.Collections;
/*
 * This class controls the player falling and reloads the scene if they fall to far
 */
public class DeathFall : MonoBehaviour {
    //Happens when the player hits something
    void OnTriggerEnter2D(Collider2D other)
    {
        //If it is the player
        if (other.gameObject.CompareTag("Player"))
        {
            //Reload the scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
           
    }
}
