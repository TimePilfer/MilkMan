using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEnemy : MonoBehaviour {

    public int currentHealth;
    //Bool to decide if the object should be destroyed
    public bool destroyOnImpact;
    //The time the bullet should exist.
    public AnimationClip lifetime;

    public Damage Damage;

    //Destroys the gameobject when the object collides with something
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (destroyOnImpact)
        {
            Destroy(gameObject);
        }
    }



    // Use this for initialization
    void Start () {
        Damage = GetComponent<Damage>();
        
    }
	
	// Update is called once per frame
	void Update () {
        
        

        if (Damage.health <= 0)
        {

            //Sets the destroy time for the gameobject
            Destroy(gameObject, lifetime.length + 1f);
        }

        
        
    }
}
