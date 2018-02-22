using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * This class sets whether the game over menu buttons are interactable or not. They will be interactable when dead only.
 */
public class ButtonInteract : MonoBehaviour {

    //public Damage playerHealth;             // Reference to the player's health.

    Button anim;                          // Reference to the animator component.

    void Awake()
    {
        // Set up the reference to the button.
        anim = GetComponent<Button>();
        //Make in not interactable
        anim.interactable = false;
    }

    void Update()
    {

        // If the player has run out of health...
        if (Damage.player.health <= 0)
        {
            // ... make the button interactable
            anim.interactable = true;
        }
    }
}
