using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {

    public GameObject test;

	// Use this for initialization
	void Start () {
        test = GameObject.Find("PauseCanvas");
	}
	
	// Update is called once per frame
	void Update () {

        if(test != null)
        {
            if (GetComponent<Pause>().isPaused)
            {
                test.SetActive(true);

                Time.timeScale = 0;
            }
            else
            {
                test.SetActive(false);

                if(!Input.GetButton("Weapons"))
                {
                    Time.timeScale = 1;
                }
                
            }
        }
        else
        {
            test = GameObject.Find("PauseCanvas");

            GetComponent<Pause>().isPaused = false;
        }
        
    }
}
