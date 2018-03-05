using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * This class handles what happens for a gameover. This includes setting animation triggers and moving the character.
 */
public class GameOver : MonoBehaviour
{
    //public int playerHealth;             // Reference to the player's health.
    public float restartDelay = 2f;         // Time to wait before restarting the level

    Animator anim;                          // Reference to the animator component.
    float restartTimer;                     // Timer to count up to restarting the level

    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
        //playerHealth = Damage.player.health;
    }

    void Update()
    {
        // If the player has run out of health...
        if (Damage.player.health <= 0)
        {
            // ... tell the animator the game is over.
            anim.SetBool("Dead", true);
            //anim.SetTrigger("GameOver");

            // .. increment a timer to count up to restarting.
            restartTimer += Time.deltaTime;

            // .. if it reaches the restart delay...
            if (restartTimer >= restartDelay)
            {
                // .. then reload the currently loaded level.
                //UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            anim.SetBool("Dead", false); // set the death bool to false
        }
    }
}
