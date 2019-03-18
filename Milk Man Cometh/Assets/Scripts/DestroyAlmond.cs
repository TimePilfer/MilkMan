using UnityEngine;
using System.Collections;
/*
 * Handles destroying objects. This is mostly used by attacks that spawn in, like the player's shots.
 */
public class DestroyAlmond : MonoBehaviour
{
    //Bool to decide if the object should be destroyed
    public bool destroyOnImpact = false;
    //The time the bullet should exist.
    public float bulletLife = 5.0f;

    void Awake()
    {
        //Sets the destroy time for the gameobject
        Destroy(gameObject, bulletLife);

    }

    //Destroys the gameobject when the object collides with something
    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);

            Debug.Log("Destroy");
        }

    }

}
