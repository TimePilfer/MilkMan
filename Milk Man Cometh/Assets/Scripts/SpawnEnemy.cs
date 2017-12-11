using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{

    //The method of spawning (random = choose a spawn point randomly; onebyone = spawn an object on spawnpoint #1 , the next will be spawned on spawnpoint #2 ,...)
    public enum SpawnType { Random, OneByOne }

    [Header("Main parameters")]
    public SpawnType spawnType;
    public GameObject[] spawnPoints;    //The array that will contain the different spawn points
    public string toSpawnResourceName = "GameObject";
    public string animationToPlay = "Open";

    [Header("Extra parameters")]
    public int numberOfObjectsToSpawnOnContact = 1;
    public int maxGameobjectsToSpawn = 5;

    private int nextSpawnPointIndex = 0;
    private int spawnedObjects = 0;
    private GameObject toSpawn;

    public bool isWaitToSpawn = false;
    private bool isSpawning = false;

    public float xOffset;

    //public GameObject[] obj;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        toSpawn = Resources.Load(toSpawnResourceName) as GameObject;    //Load the gameobject to spawn from resources
        //obj = spawnPoints[];
        
    }

    private void Update()
    {
        if (isSpawning)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName(animationToPlay) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                isSpawning = false;
                GameObject spawnPoint = spawnPoints[0]; //Set a default spawnpoint to avoid errors
                Instantiate(toSpawn, spawnPoint.transform.position, Quaternion.identity);   //Spawn the wanted GameObject
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") //Check for what you want about the collider here
        {
            //PlayAnimation();
            SpawnAnObject();
        }
    }

    private void PlayAnimation()
    {
        if (spawnedObjects >= maxGameobjectsToSpawn)    //If enough objects spawned , stop here
        { return; }
        else
        {
            anim = spawnPoints[spawnedObjects].GetComponent<Animator>();
        }
        
        anim.SetBool(animationToPlay, true); //set your animator bool name here
        anim.Play(animationToPlay); //set animation name here
    }

    private void SpawnAnObject()
    {
        if (spawnedObjects >= maxGameobjectsToSpawn)    //If enough objects spawned , stop here
            return;

        GameObject spawnPoint = spawnPoints[0]; //Set a default spawnpoint to avoid errors

        for (int i = 0; i < numberOfObjectsToSpawnOnContact; i++)
        {
            

            if (spawnType == SpawnType.Random)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            }

            else if (spawnType == SpawnType.OneByOne)
            {
                spawnPoint = spawnPoints[nextSpawnPointIndex];
                nextSpawnPointIndex++;
                if (nextSpawnPointIndex >= spawnPoints.Length)
                    nextSpawnPointIndex = 0;
            }

            if (isWaitToSpawn)
            {
                PlayAnimation();

                isSpawning = true;
                spawnedObjects++;       //Increment the number of spawned object

            }
            else
            {
                PlayAnimation();
                Instantiate(toSpawn, new Vector3(spawnPoint.transform.position.x - xOffset, 14.15439f, 2.5f), Quaternion.identity);   //Spawn the wanted GameObject
                spawnedObjects++;       //Increment the number of spawned object
            }
            

        }
    }
}