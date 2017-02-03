using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float _bulletSpeed;
    public Rigidbody2D _rb;

    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();

    }

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.velocity = new Vector2(_bulletSpeed, 0);

        _rb.AddForce(_rb.velocity, (ForceMode2D.Force));

    }
}
