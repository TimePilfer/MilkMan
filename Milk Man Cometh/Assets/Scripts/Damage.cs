using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
/*
 * This class handles all things damage and health, including the player and enemies. It includes a singleton for the player's health.
 */
public class Damage : MonoBehaviour {
    // Access the player health in other class.
    public static Damage player;
    // An int for the health.
    public int health;
    // A constant for the player's health
    public const int maxHealth = 3;

    private Animator anim;
    // A boolean to track if the player is dead
    public bool die = false;

    public UnityEngine.UI.Slider healthBar;

    

    void Awake()
    {
        //Get the animator for the enemy
        if (gameObject.tag == "Enemy")
        {
            anim = GetComponent<Animator>();
        }
        //If there is no player, set the player up
        if (player == null)
        {
            if (gameObject.tag == "Player")
            {
                player = this;

                DontDestroyOnLoad(gameObject);

                //healthBar.onValueChanged.AddListener(ListenerMethod);

            }
        }
        //If there is a player already, get rid of the second player object
        else if (player != null)
        {
            
            if (gameObject.tag == "Player")
            {
                Destroy(gameObject);

                Damage.player.health = Damage.maxHealth;
                
                BasicControls.player.anim.SetBool("Dead", false);

                //healthBar.onValueChanged.AddListener(ListenerMethod);
            }
            
        }
        

    }

    private void Update()
    {

        if (gameObject.tag == "Player")
        {
            

            if (healthBar == null)
            {
                

                healthBar = FindObjectOfType<UnityEngine.UI.Slider>();
            }

            if (health != healthBar.value)
            {
                healthBar.value = health;
            }
        }

        
        
    }

    /*
     * Handles a collision between two object. Causes the Die() method if the object(s) run out of health
     */
    void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Collision");

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {

            Debug.Log("Damage Hit");
            health--;

            
            

            if (health <= 0)
            {
                Die();
            }

        }

    }

    
     
    //public void ListenerMethod(float value)
    //{

    //    healthBar.value = health;

    //}
    /*
     * Handles when something dies or is destroyed
     */

    void Die()
    {
        if (gameObject.tag == "Enemy")
        {
            anim.SetBool("Dead", true);
            //BasicControls.player.anim.SetBool("Dead", true);
        }

        if (gameObject.tag != "Enemy" && gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
        
    }

    public int GetHealth()
    {
        return health;
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

        playerData data = new playerData();

        data.Health = health;

        bf.Serialize(file, data);

        file.Close();
    }

    public void Load()
    {

        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

        playerData data = new playerData();

        data.Health = health;

        bf.Serialize(file, data);

        file.Close();
    }

}

[Serializable]
class playerData
{

    private float health;

    public float Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

}