using UnityEngine;
using System.Collections;
/*
 * Handles destroying objects. This is mostly used by attacks that spawn in, like the player's shots.
 */
public class DestroyObject : MonoBehaviour {
    //Bool to decide if the object should be destroyed
    public bool destroyOnImpact;
    //The time the bullet should exist.
    public float lifetime = 3.0f;

    void Awake()
    {
        //Sets the destroy time for the gameobject
        Destroy(gameObject, lifetime);

    }

    //Destroys the gameobject when the object collides with something
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(destroyOnImpact)
        {
            Destroy(gameObject);
        }
    }

}
