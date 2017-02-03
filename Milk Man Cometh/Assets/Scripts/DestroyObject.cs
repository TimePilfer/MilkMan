using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

    public bool destroyOnImpact;
    public float lifetime = 3.0f;
    void Awake()
    {
        Destroy(gameObject, lifetime);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(destroyOnImpact)
        {
            Destroy(gameObject);
        }
    }

}
