using UnityEngine;
using System.Collections;
using System;
/*
 * This class handles all of the player's controls. This includes all moving, jumping, speed, as well as checking which way the character is facing, flipping the character,
 * and checking if the player is on the ground or not. Shooting, however, is handled in the Arm class, with shots handled in the bullet script. Arm movement is also in
 * the Arm script.
 */
public class BasicControls : MonoBehaviour
{
    public GameObject weaponWheel;

    public static BasicControls player;

    public PowerUp powerUp;

    public bool myBool = false;

    public bool isPaused;

    const int RAD_ZERO = 0;
    const int RAD_FIRST_WEAPON = 45;
    const int RAD_SECOND_WEAPON = 90;
    const int RAD_THIRD_WEAPON = 135;
    const int RAD_FOURTH_WEAPON = 180;
    const int RAD_FIFTH_WEAPON = 225;
    const int RAD_SIXTH_WEAPON = 270;
    const int RAD_SEVENTH_WEAPON = 315;
    const int RAD_EIGHTH_WEAPON = 360;

    // and expose static members through properties
    // this way, you have a lot more control over what is actually being sent out.
    public static bool MyBool { get { return player ? player.myBool : false; } }

    public static bool facingRight = true;
    public bool jump = false;

    public float moveForce = 365f;
    public float maxSpeed = 10f;
    public float jumpforce = 1000f;
    public Transform groundcheck;

    public bool isGround = false;
    protected bool isGrounded = false;
    protected bool isCrouched = false;
    public Animator anim;
    public Animator animHealth;
    protected Animation ani;
    protected Rigidbody2D rb2d;
    protected BoxCollider2D PlayerCollision;

    public float yValue = 0f; // Used to make it look like it's shot from the gun itself (offset)
    public float xValue = 0f; // Same as above

    //Vector2 fwd;
    public GameObject Shot;
    public Transform ShotSpawn;

    protected bool test = false;
    protected double speedReduction = 0.1;

    protected float jumpdelay = 0.1f;
    protected bool canJump = false;

    //= this.transform.GetComponents<CircleCollider2D>();// = GetComponent<BoxCollider2D>();
    protected float crouchHeight = 2f;
    protected float standHeight = 2.24f;
    protected float crouchOffset = -0.75f;

    //Dodge/Roll Variables
    public float evadeTime; // this tells us how long the evade takes
    public float evadeDistance; // this tells us how far player will evade
    public bool evading; //is the character currently dodging?
    public float cooldownTimer; //the amount of time a player must wait between rolls
    //private Input InputManager; //the input manager from unity
    private float evadeTimer; //the timer until the next roll can happen
    public float moveSpeed; //the movement speed of the roll
    public Vector3 moveDirection; // the direction the character is rolling
    public Arm arm; //The Robot's arm
    public static bool invincible = false;
    public bool invincible2 = false;

    public GameObject robotArm;

    //Prefab for the bullets in the special attack
    public Rigidbody2D bulletPrefab;

    //public Arm arm;

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();

        //animHealth = FindObjectOfType<UnityEngine.UI.Slider>().GetComponentInChildren<Animator>();
        animHealth = GameObject.Find("HUDCanvas/Slider/Handle Slide Area/Handle").GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>();

        arm = GameObject.Find("Arm").GetComponent<Arm>();

        robotArm = GameObject.Find("Arm");

        PlayerCollision = GetComponent<BoxCollider2D>();
        //ani = GetComponent<Animation>();
        player = this;
        DontDestroyOnLoad(gameObject);

        weaponWheel = GameObject.Find("WeaponWheel");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.1f);

        if (animHealth == null)
        {
            //Need better solution to getting the healthbar later
            animHealth = GameObject.Find("HUDCanvas/Slider/Handle Slide Area/Handle").GetComponent<Animator>();
        }
        
        if (GameObject.Find("respawnPoint").GetComponent<Pause>().isPaused)
        {
            isPaused = true;
        }
        else
        {
            isPaused = false;
        }

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RobotDeath"))
        {
            //OnCollisionExit();

            if (Input.GetButtonDown("Jump") && isGround)
            {
                jump = true;
            }

            if (isGrounded && Input.GetButtonDown("Fire3"))
            {
                Crouch();
            }

            if (Input.GetButtonUp("Fire3") && isCrouched)
            {
                StandUp();
            }
        }

        ProcessEvasion();

    }

    void FixedUpdate()
    {
        Vector2 parentSpeed = GetComponent<Rigidbody2D>().velocity;

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RobotDeath"))
        {
            if (!isPaused)
            {
                GroundedUpdater();

                float h = Input.GetAxisRaw("Horizontal");

                anim.SetFloat("Speed", Mathf.Abs(h));

                animHealth.SetFloat("Speed", Mathf.Abs(h));

                if (h * rb2d.velocity.x < maxSpeed)
                {
                    rb2d.AddForce(Vector2.right * h * moveForce);
                }

                if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
                {
                    rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
                }

                if (h > 0 && !facingRight)
                {
                    Flip();
                }

                if (h < 0 && facingRight)
                {
                    Flip();
                }

                if (jump)
                {
                    anim.SetTrigger("Jump");

                    animHealth.SetTrigger("Jump");

                    jump = false;
                    StartCoroutine(jumpLag());
                }

                if (canJump)
                {
                    //rb2d.AddForce(new Vector2(0f, jumpforce));
                    //rb2d.velocity += 8f * Vector2.up;
                    rb2d.AddForce(Vector3.up * jumpforce, ForceMode2D.Impulse);
                    isGrounded = false; //Avoid direct double jump
                    canJump = false;
                }

                if (Input.GetButton("Horizontal"))
                    test = false;
                else
                    test = true;

                if (test)
                {
                    rb2d.velocity = new Vector2((rb2d.velocity.x / 2), rb2d.velocity.y);
                }

                if (MilkLusted.canSpecial && Input.GetButton("Fire2"))
                {
                    Debug.Log("Special");

                    for (int i = 0; i < 100; i++)
                    {
                        //Add logic for doing the special attack
                        Rigidbody2D bPrefab = Instantiate(bulletPrefab, new Vector3(transform.position.x + xValue, transform.position.y + yValue,
                            transform.position.z), transform.rotation) as Rigidbody2D;

                        Vector2 dir = (new Vector2(UnityEngine.Random.insideUnitCircle.normalized.x, UnityEngine.Random.insideUnitCircle.normalized.y));

                        bPrefab.velocity = (dir * 35 + parentSpeed);
                    }
                    
                    MilkLusted.LustMeter = 0;

                    MilkLusted.canSpecial = false;
                }

                if (Input.GetButton("Weapons"))
                {
                    Time.timeScale = 0.1f;

                    //Implement logic to make the wheel popup.
                    weaponWheel.SetActive(true);
                    weaponSelected(arm.ls.x);
                }
                else
                {
                    Time.timeScale = 1f;

                    weaponWheel.SetActive(false);
                }
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        xValue = -(xValue);
    }

    IEnumerator jumpLag()
    {
        yield return new WaitForSeconds(jumpdelay);

        canJump = true;
    }

    void Crouch()
    {
        isGrounded = false;
        isCrouched = true;
        PlayerCollision.size = new Vector2(PlayerCollision.size.x, crouchHeight);
        //PlayerCollision.offset = new Vector2(0, crouchOffset);
        anim.SetTrigger("Duck");
    }

    void StandUp()
    {
        isGrounded = true;
        isCrouched = false;
        PlayerCollision.size = new Vector2(PlayerCollision.size.x, standHeight);
        //PlayerCollision.offset = new Vector2(0, 0);
        anim.ResetTrigger("Duck");
    }

    void GroundedUpdater()
    {
        isGround = false; //Set to false every frame by default
        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(transform.position, Vector2.down, 5f);
        // you can increase RaycastLength and adjust direction for your case
        foreach (var hited in hit)
        {
            if (hited.collider.gameObject == gameObject) //Ignore my character
                continue;
            // Don't forget to add tag to your ground
            if (hited.collider.gameObject.tag == "Ground")
            { //Change it to match ground tag
                isGround = true;
            }
        }
    }

    void ProcessEvasion()
    {
        cooldownTimer = Mathf.Max(0f, cooldownTimer - Time.deltaTime);

        if (!evading && cooldownTimer == 0 && Input.GetButton("Roll"))
        {
            //arm.SetActive(false);// = false;
            evading = true;
            
            evadeTimer = evadeTime;
            anim.SetTrigger("Evading");
            animHealth.SetTrigger("Roll");
            Debug.Log("Rolling");
        }

        if (evading)
        {
            robotArm.SetActive(false);
            evading = false;
            invincible = true;
            invincible2 = true;
            StartCoroutine(WaitAndPrint(1.1F));

            evadeTimer = Mathf.Max(0f, evadeTimer - Time.deltaTime);

            // Evasion overrides speed and direction
            moveDirection = rb2d.transform.forward; // evasion = full speed forward
            moveSpeed = evadeDistance / evadeTime;

            cooldownTimer = 3.0f;
            
        }
        if (evadeTimer == 0)
        {
            //anim.SetBool("Evading", false);

            anim.ResetTrigger("Evading");

        }

    }
    
    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        robotArm.SetActive(true);
        invincible = false;
        invincible2 = false;
        Debug.Log("WaitAndPrint " + Time.time);
    }

    IEnumerator Special(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        robotArm.SetActive(true);
        invincible = false;
        invincible2 = false;
        Debug.Log("WaitAndPrint " + Time.time);
    }

    void weaponSelected(float weaponSelection)
    {
        if (weaponSelection > RAD_ZERO && weaponSelection <= RAD_FIRST_WEAPON)
        {
            Array.Clear(powerUp.weaponSelected, 0, powerUp.weaponSelected.Length);

            powerUp.weaponSelected[0] = true;
        }
        if (weaponSelection > RAD_FIRST_WEAPON && weaponSelection <= RAD_SECOND_WEAPON)
        {
            Array.Clear(powerUp.weaponSelected, 0, powerUp.weaponSelected.Length);

            powerUp.weaponSelected[1] = true;
        }
        if (weaponSelection > RAD_SECOND_WEAPON && weaponSelection <= RAD_THIRD_WEAPON)
        {
            Array.Clear(powerUp.weaponSelected, 0, powerUp.weaponSelected.Length);

            powerUp.weaponSelected[2] = true;
        }
        if (weaponSelection > RAD_THIRD_WEAPON && weaponSelection <= RAD_FOURTH_WEAPON)
        {
            Array.Clear(powerUp.weaponSelected, 0, powerUp.weaponSelected.Length);

            powerUp.weaponSelected[3] = true;
        }
        if (weaponSelection > RAD_FOURTH_WEAPON && weaponSelection <= RAD_FIFTH_WEAPON)
        {
            Array.Clear(powerUp.weaponSelected, 0, powerUp.weaponSelected.Length);

            powerUp.weaponSelected[4] = true;
        }
        if (weaponSelection > RAD_FIFTH_WEAPON && weaponSelection <= RAD_SIXTH_WEAPON)
        {
            Array.Clear(powerUp.weaponSelected, 0, powerUp.weaponSelected.Length);

            powerUp.weaponSelected[5] = true;
        }
        if (weaponSelection > RAD_SIXTH_WEAPON && weaponSelection <= RAD_SEVENTH_WEAPON)
        {
            Array.Clear(powerUp.weaponSelected, 0, powerUp.weaponSelected.Length);

            powerUp.weaponSelected[6] = true;
        }
        if (weaponSelection > RAD_SEVENTH_WEAPON && weaponSelection <= RAD_EIGHTH_WEAPON)
        {
            Array.Clear(powerUp.weaponSelected, 0, powerUp.weaponSelected.Length);

            powerUp.weaponSelected[7] = true;
        }
    }
}
