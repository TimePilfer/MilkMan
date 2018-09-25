using UnityEngine;
using System.Collections;
/*
 * This class controls the bullet that comes out of the arm of the character. Right now it is coming out as individual 
 * projectiles, but may change to one stream of milk.
 */
public class Bullet : MonoBehaviour {
    
    //The speed of the bullet as it moves through the scene.
    public float _bulletSpeed;
    //The rigidbody of the bullet
    public Rigidbody2D _rb;

    void Start()
    {
        //Gets the bullet's rigidbody
        _rb = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        //Gets the bullet's rigidbody
        _rb = GetComponent<Rigidbody2D>();
        //Puts a velocity on the bullet based on the bullet speed
        _rb.velocity = new Vector2(_bulletSpeed, 0);

        //Adds a force to the bullet based on the velocity
        _rb.AddForce(_rb.velocity, (ForceMode2D.Force));

    }

    void OnCollisionEnter2D(Collision2D c)
    {

        //if (gameObject.tag == "Bullet")
        //{
            var joint = gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = c.rigidbody;
        //}
    }
}
