using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public bool isPaused = false;

    Animator anim;

    public float restartDelay = 0.3f;         // Time to wait before restarting the level

    float restartTimer = 0f;                     // Timer to count up to restarting the level

    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
        //playerHealth = Damage.player.health;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == true)
            {
                isPaused = false;
                //anim.SetBool("Paused", false);

                //this.gameObject.SetActive(false);



                //Time.timeScale = 1;
            }
            else
            {
                isPaused = true;

                //anim.SetBool("Paused", true);
                //this.gameObject.SetActive(true);

                //restartTimer += Time.deltaTime;

                //if (restartTimer >= restartDelay)
                //{
                //    Time.timeScale = 0;
                //}


            }
        }

        if (isPaused == false)
        {

        }

        else
        {

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                //if (GameObject.Find("PauseCanvas").activeSelf)
                //{
                //    //Time.timeScale = 0;
                //}

                
            }


        }


        


    }


}