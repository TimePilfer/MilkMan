using System;
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
        //weaponUnlocks[9] = true; // Possible second starting shot - Chocolate Milk?
    }
	
	// Update is called once per frame
	void Update () {

        if (weaponUnlocks[0] && (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)))
        {
            Milk();
        }
        if (weaponUnlocks[1] && (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)))
        {
            RiceMilk();
        }
        if (weaponUnlocks[2] && (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)))
        {
            SkimMilk();
        }
        if (weaponUnlocks[3] && (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)))
        {
            GoatMilk();
        }
        if (weaponUnlocks[4] && (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)))
        {
            StrawberryMilk();
        }
        if (weaponUnlocks[5] && (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6)))
        {
            AlmondMilk();
        }
        if (weaponUnlocks[6] && (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7)))
        {
            HempMilk();
        }
        if (weaponUnlocks[7] && (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8)))
        {
            PowderedMilk();
        }
        if (weaponUnlocks[8] && (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9)))
        {
            NanobotMilk();
        }
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        //Machine Gun Like Shots, high rof, low accuracy
        if (other.gameObject.name == "Rice Milk")
        {
            Debug.Log("Rice Milk");
            weaponUnlocks[1] = true;
        }

        //Skim Milk - more focused shot with a tighter stream
        if (other.gameObject.name == "Skim Milk")
        {
            Debug.Log("Skim Milk");
            weaponUnlocks[2] = true;
        }

        //Goat Milk - higher knockback
        if (other.gameObject.name == "Goat Milk")
        {
            Debug.Log("Goat Milk");
            weaponUnlocks[3] = true;
        }

        //Strawberry Milk - explosive shot
        if (other.gameObject.name == "Strawberry Milk")
        {
            Debug.Log("Strawberry Milk");
            weaponUnlocks[4] = true;
        }
        //Almond Milk - bouncing shots
        if (other.gameObject.name == "Almond Milk")
        {
            Debug.Log("Almond Milk");
            weaponUnlocks[5] = true;
        }

        //Hemp Milk - smoke gun, makes enemies slow down, then lay down and turn to milk
        if (other.gameObject.name == "Hemp Milk")
        {
            Debug.Log("Hemp Milk");
            weaponUnlocks[6] = true;
        }

        //Powdered Milk - charge shot
        if (other.gameObject.name == "Powdered Milk")
        {
            Debug.Log("Powdered Milk");
            weaponUnlocks[7] = true;
        }

        //Nanobot Milk - DoT
        if (other.gameObject.name == "Nanobot Milk")
        {
            Debug.Log("Nanobot Milk");
            weaponUnlocks[8] = true;
        }

    }

    public void Milk()
    {
        bulletSpawn.bulletSpawnInstance.fireRate = 0.1f;
        bulletSpawn.bulletSpawnInstance.shotSpeed = 30;
        bulletSpawn.bulletSpawnInstance.coneRotation = 30;
    }

    public void RiceMilk()
    {
        bulletSpawn.bulletSpawnInstance.fireRate = 0.001f;
        bulletSpawn.bulletSpawnInstance.shotSpeed = 40;
        bulletSpawn.bulletSpawnInstance.coneRotation = 40;
    }

    private void SkimMilk()
    {
        bulletSpawn.bulletSpawnInstance.fireRate = 0.01f;
        bulletSpawn.bulletSpawnInstance.shotSpeed = 40;
        bulletSpawn.bulletSpawnInstance.coneRotation = 10;
    }

    private void GoatMilk()
    {
        bulletSpawn.bulletSpawnInstance.fireRate = 0.01f;
        bulletSpawn.bulletSpawnInstance.shotSpeed = 40;
        bulletSpawn.bulletSpawnInstance.coneRotation = 10;
    }

    private void NanobotMilk()
    {
        throw new NotImplementedException();
    }

    private void PowderedMilk()
    {
        throw new NotImplementedException();
    }

    private void HempMilk()
    {
        throw new NotImplementedException();
    }

    private void AlmondMilk()
    {
        throw new NotImplementedException();
    }

    private void StrawberryMilk()
    {
        throw new NotImplementedException();
    }

}
