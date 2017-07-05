using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnPoint : MonoBehaviour {

    public static spawnPoint playerSpawn;

    public Transform spawn;

    public void setSpawn()
    {
        //spawn = GameObject.FindGameObjectWithTag("spawn").transform;
        transform.position = spawn.position;
    }

    void Update()
    {
        if (Damage.player.health <= 0)
        {

        }

        if (spawn == null)
        {
            spawn = GameObject.FindGameObjectWithTag("spawn").transform;
            setSpawn();
        }
    }
}
