using UnityEngine;
using System.Collections;
/*
 * This class controls the bullet spawning that comes out of the arm of the character. It controls the speed that they spawn at and the location
 */
public class bulletSpawn : MonoBehaviour {
    //The time that the next bullet can be fired
    private float nextFire;
    //The speed of the shot
    public float shotSpeed;
    //The rate of fire of the character
    public float fireRate;
    //The bullet prefab
    public Rigidbody2D bulletPrefab;
    public float yValue = 0f; // Used to make it look like it's shot from the gun itself (offset)
    public float xValue = 0f; // Same as above

    public bool isPaused;

    public Animator anim;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (GameObject.Find("respawnPoint").GetComponent<Pause>().isPaused)
        {
            isPaused = true;
        }
        else
        {
            isPaused = false;
        }

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RobotDeath"))
        {
            if (!isPaused)
            {
                //If the next bullet is able to fire and the fire button is being pressed
                if (Input.GetButton("Fire1") && Time.time > nextFire)
                {
                    //Sets the time for the next bullet to be able to be fired
                    nextFire = Time.time + fireRate;
                    //Spawns a new bullet based on the bullet prefab and the location of the bullet spawn position
                    Rigidbody2D bPrefab = Instantiate(bulletPrefab, new Vector3(transform.position.x + xValue, transform.position.y + yValue,
                        transform.position.z), transform.rotation) as Rigidbody2D;
                    //The position of the camera, and therefore the character
                    Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
                    //The mouse position in relation to the player
                    Vector3 dir = (Input.mousePosition - sp).normalized;
                    //Shoots the bullet toward the mouse
                    bPrefab.AddForce(dir * shotSpeed);
                }
            }

        }
    }
}
