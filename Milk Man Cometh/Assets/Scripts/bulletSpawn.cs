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

    public static bulletSpawn bulletSpawnInstance;

    //public GameObject stream;

    public float yValue = 0f; // Used to make it look like it's shot from the gun itself (offset)
    public float xValue = 0f; // Same as above
    public float coneRotation = 0f;

    public bool isPaused;

    public Animator anim;

    void Start()
    {
        anim = GetComponentInParent<Animator>();

        bulletSpawnInstance = this;
    }

    // Update is called once per frame
    void Update ()
    {
        //xValue = transform.forward.x + Random.insideUnitSphere.x * 0.3f;
        //yValue = transform.forward.y + Random.insideUnitSphere.y * 0.3f;
        Vector2 parentSpeed = GetComponentInParent<Rigidbody2D>().velocity;

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
                    Vector2 sp = Camera.main.WorldToScreenPoint(transform.position);


                    //The mouse position in relation to the player
                    Vector2 dir = (new Vector2(Input.mousePosition.x, Input.mousePosition.y) - sp).normalized;
                    Vector2 actualDir = GetRandomInsideCone(1) * dir;


                    //Shoots the bullet toward the mouse
                    bPrefab.velocity = (actualDir * shotSpeed + parentSpeed);

                }
            }

        }


    }

    Quaternion GetRandomInsideCone(float conicAngle)
    {
        // random tilt right (which is a random angle around the up axis)
        Quaternion randomTilt = Quaternion.AngleAxis(Random.Range(0f, conicAngle), Vector3.up);

        // random spin around the forward axis
        Quaternion randomSpin = Quaternion.AngleAxis(Random.Range(0f, coneRotation), Vector3.forward);

        // tilt then spin
        return (randomSpin * randomTilt);
    }
}
