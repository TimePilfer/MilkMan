using UnityEngine;
using System.Collections;

public class bulletSpawn : MonoBehaviour {

    private float nextFire;
    public float shotSpeed;
    public float fireRate;

    public Rigidbody2D bulletPrefab;
    public float yValue = 0f; // Used to make it look like it's shot from the gun itself (offset)
    public float xValue = 0f; // Same as above

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {


            nextFire = Time.time + fireRate;

            Rigidbody2D bPrefab = Instantiate(bulletPrefab, new Vector3(transform.position.x + xValue, transform.position.y + yValue,
                transform.position.z), transform.rotation) as Rigidbody2D;

            Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = (Input.mousePosition - sp).normalized;
            bPrefab.AddForce(dir * shotSpeed);

        }
    }
}
