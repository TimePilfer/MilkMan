using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

    public int health;

    private Animator anim;

    public bool die = false;

    void Awake()
    {
        if(gameObject.tag == "Enemy" || gameObject.tag == "Player")
        {
            anim = GetComponent<Animator>();
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            health--;

                if(health<=0)
                {
                    Die();
                }
        }

        
    }

    void Die()
    {
        if (gameObject.tag == "Enemy" || gameObject.tag == "Player")
        {
            anim.SetTrigger("Dead");
        }

        if (gameObject.tag != "Enemy" && gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
        
    }
    
}
