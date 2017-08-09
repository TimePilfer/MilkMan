using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnPoint : MonoBehaviour {

    public static spawnPoint playerSpawn;

    public static Transform spawn;

    public void setSpawn()
    {
        //spawn = GameObject.FindGameObjectWithTag("spawn").transform;
        transform.position = spawn.position;
    }

    void Awake()
    {

        if (spawn == null)
        {
            spawn = GameObject.FindGameObjectWithTag("spawn").transform;
            setSpawn();
        }
    }
}
