using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteract : MonoBehaviour {

    public Damage playerHealth;             // Reference to the player's health.

    Button anim;                          // Reference to the animator component.

    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Button>();
        anim.interactable = false;
    }

    void Update()
    {

        // If the player has run out of health...
        if (playerHealth.health <= 0)
        {
            // ... tell the animator the game is over.
            anim.interactable = true;
        }
    }
}
