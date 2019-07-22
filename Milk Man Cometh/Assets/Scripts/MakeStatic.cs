using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStatic : MonoBehaviour {

    private static MakeStatic staticInstance;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (staticInstance == null)
        {
            DontDestroyOnLoad(this);
            staticInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }
}
