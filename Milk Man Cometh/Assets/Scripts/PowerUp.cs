using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public static bulletSpawn bullet;

    public bool[] weaponUnlocks = new bool[10];
    

    // Use this for initialization
    void Start () {
        bullet = GetComponent<bulletSpawn>();
        weaponUnlocks[0] = true; // The starting shot - Regular Milk
 
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        //Machine Gun Like Shots, high rof, low accuracy
        if (other.gameObject.name == "Rice Milk")
        {
            Debug.Log("Rice Milk");
            bulletSpawn.bulletSpawnInstance.fireRate = 0.001f;
            bulletSpawn.bulletSpawnInstance.shotSpeed = 40;
            bulletSpawn.bulletSpawnInstance.coneRotation = 40;
            weaponUnlocks[1] = true;
        }

        //Skim Milk - more focused shot with a tighter stream
        if (other.gameObject.name == "Skim Milk")
        {
            Debug.Log("Skim Milk");
            bulletSpawn.bulletSpawnInstance.fireRate = 0.01f;
            bulletSpawn.bulletSpawnInstance.shotSpeed = 40;
            bulletSpawn.bulletSpawnInstance.coneRotation = 10;
            weaponUnlocks[2] = true;
        }

        //Goat Milk - higher knockback
        if (other.gameObject.name == "Goat Milk")
        {
            Debug.Log("Goat Milk");
            bulletSpawn.bulletSpawnInstance.fireRate = 0.01f;
            bulletSpawn.bulletSpawnInstance.shotSpeed = 40;
            bulletSpawn.bulletSpawnInstance.coneRotation = 10;
            weaponUnlocks[3] = true;
        }

        //Strawberry Milk - explosive shot

        //Almond Milk - bouncing shots

        //Hemp Milk - smoke gun, makes enemies slow down, then lay down and turn to milk

        //Powdered Milk - charge shot

        //Nanobot Milk - DoT
    }

}
