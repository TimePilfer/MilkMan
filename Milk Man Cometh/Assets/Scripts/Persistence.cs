using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Persistence : MonoBehaviour
{
    public static Persistence control;

    public float health;
    public float experience;
    public Transform spawnPoint;

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            // There can be only one!
            Destroy(gameObject);
        }
    }
}
