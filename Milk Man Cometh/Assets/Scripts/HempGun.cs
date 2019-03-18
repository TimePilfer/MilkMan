using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HempGun : MonoBehaviour {

    public float damage = 50;
    // An int for the health.
    public int health;

    private Animator anim;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(ExplosionDelete());

        //Get the animator for the enemy
        if (gameObject.tag == "Enemy")
        {
            anim = GetComponent<Animator>();
        }
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);

            Debug.Log("Damage Hit");
            health--;

            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        if (gameObject.tag == "Enemy")
        {
            anim.SetBool("Dead", true);
            gameObject.GetComponent<Collider2D>().enabled = false;
            MilkLusted.LustMeter += 1;
            //BasicControls.player.anim.SetBool("Dead", true);
        }

        if (gameObject.tag != "Enemy" && gameObject.tag != "Player" && gameObject.tag != "Bullet")
        {
            Destroy(gameObject);
        }

    }

    IEnumerator ExplosionDelete()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
