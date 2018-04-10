using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {


    public string sceneName;
    public float xPosition;
    public float yPosition;

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            other.transform.position = new Vector3(xPosition, yPosition, 0);
            SceneManager.LoadScene(sceneName);
        }
    }
}
