using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Testing script for adding or subtracting health from the player.
 */
public class AdjustScript : MonoBehaviour {
    
	void OnGUI()
    {
        if(GUI.Button(new Rect(10, 100, 100, 30), "Health up"))
        {
            Damage.player.health += 1;
        }

        if (GUI.Button(new Rect(10, 130, 100, 30), "Health down"))
        {
            Damage.player.health -= 1;
        }
    }
}
