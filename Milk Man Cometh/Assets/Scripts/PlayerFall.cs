using UnityEngine;
using System.Collections;
/*
 * This class handles the player falling.
 */
public class PlayerFall : MonoBehaviour {
    //The time the player has before the event happens
    public float fallDelay;
    //The player object
    private Rigidbody2D rb2d;

	// Get the player object
	void Awake ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
    //On collision, will invoke the fall method
    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
        }
    }
    //Makes the player kinematic
    void Fall()
    {
        rb2d.isKinematic = false;
    }

}
