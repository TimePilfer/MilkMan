using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour
{

    public int level;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClick()
    {
        SceneManager.LoadScene(1);
    }

    public void closeGame()
    {
        Application.Quit();
    }
}
