using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : MonoBehaviour {

	//// Use this for initialization
	//void Start () {
		
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}

    int runSpeed = 3;
    int biteRange = 3;
    int walkSpeed = 1;
    int rotationSpeed = 3;
    int attackRange = 3;
    int chaseRange = 10;
    int giveUpRange = 20;
    int dontComeCloserRange = 2;
    float attackRepeatTime = 0.9f;
    CharacterController controller;
    public Transform target; 
    string biteAnim;
    string idleAnim;
    string idleaimAnim;
    string idleaimhighAnim;
    string idleaimlowAnim;
    string runAnim;
    string walkAnim;
    string shootAnim;
    private int initialSpeed = 0;
    bool chasing = false;
    private int attackTime = 1;
    Transform myTransform; 
    bool PauseRunning = false;
    Animation Anim;
    int lookStrength = 2;
    bool option = false;
    bool option2 = false;
    Transform Proj;
    Transform MuzzleFlash;
    int BulletSpeed = 20;
    Transform BulletPos;
    private string idleaimAnimReal;
    AudioSource AudSource;
    //private var currentMuzzle;




    void Awake()
    {

        myTransform = transform;
    }



    void Start()
    {
        Anim.Play(idleAnim);
        target = GameObject.FindWithTag("Player").transform;

    }



    void Update()
    {
        Debug.DrawLine(target.position, BulletPos.position, Color.cyan);
        var distance = (target.position - BulletPos.position).magnitude;

        if (target.position.y == transform.position.y)
        {
            idleaimAnimReal = idleaimAnim;
        }
        if (target.position.y > transform.position.y)
        {
            idleaimAnimReal = idleaimhighAnim;
        }
        if (target.position.y < transform.position.y)
        {
            idleaimAnimReal = idleaimlowAnim;
        }

        BulletPos.LookAt(target);


        if (distance < chaseRange)
        {

            chasing = true;

        }

        if (chasing)
        {
            if (PauseRunning == false)
            {

                Vector3 targetRot = new Vector3(target.position.x, this.transform.position.y, target.position.z);
                transform.LookAt(targetRot);

                controller.SimpleMove(runSpeed * transform.forward);

                Anim.Play(runAnim);
            }
        }
        else
        {
            Anim.Play(idleAnim);

        }

        if (distance > giveUpRange)
        {

            chasing = false;

        }

        if (distance < biteRange)
        {

            Anim.Play(biteAnim);
            attackRepeatTime = 0;

        }

        if (distance < dontComeCloserRange)
        {
            //            targetRotation = Quaternion.LookRotation (target.position - transform.position);
            //    
            //               str = Mathf.Min (lookStrength * Time.deltaTime, 1);

            Vector3 targetRot = new Vector3(target.position.x, this.transform.position.y, target.position.z);
            //       transform.rotation.z = Quaternion.Lerp (transform.rotation, targetRotation, str);
            transform.LookAt(targetRot);
            PauseRunning = true;
            if (option == false)
            {
                InvokeRepeating("Fire", 0, attackRepeatTime);
                option = true;
                dontComeCloserRange += 5;
                option2 = true;
            }
        }
        if (distance > dontComeCloserRange)
        {
            PauseRunning = false;
            CancelInvoke();
            option = false;
            if (option2 == true)
            {
                dontComeCloserRange -= 5;
                option2 = false;
            }
        }

        if (PauseRunning == true)
        {
            Anim.Play(idleaimAnim);


        }
    }

    void Fire()
    {
        Anim.Play(shootAnim);
        attackRepeatTime = 2;
        Debug.Log("Shoot1");
        Transform Bullet;
        GameObject Muzzle;
        AudSource.Play();
        Bullet = Instantiate(Proj, BulletPos.position, BulletPos.rotation);
        Muzzle = Instantiate(MuzzleFlash, BulletPos.position, BulletPos.rotation).gameObject;
        Bullet.GetComponent< Rigidbody > ().AddForce(Bullet.transform.forward * BulletSpeed);
        Debug.Log("Shoot");

    }
}
