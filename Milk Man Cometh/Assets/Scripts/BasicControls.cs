using UnityEngine;
using System.Collections;
/*
 * This class handles all of the player's controls. This includes all moving, jumping, speed, as well as checking which way the character is facing, flipping the character,
 * and checking if the player is on the ground or not. Shooting, however, is handled in the Arm class, with shots handled in the bullet script. Arm movement is also in
 * the Arm script.
 */
public class BasicControls : MonoBehaviour {

    public static BasicControls player;

    public bool myBool = false;

    public bool isPaused;

    // and expose static members through properties
    // this way, you have a lot more control over what is actually being sent out.
    public static bool MyBool { get { return player ? player.myBool : false; } }

    public static bool facingRight = true;
    public bool jump = false;

    public float moveForce = 365f;
    public float maxSpeed = 10f;
    public float jumpforce = 1000f;
    public Transform groundcheck;

    protected bool isGround = false;
    protected bool isGrounded = true;
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

    // Use this for initialization
    void Awake ()
    {
        anim = GetComponent<Animator>();

        animHealth = FindObjectOfType<UnityEngine.UI.Slider>().GetComponentInChildren<Animator>();

        rb2d = GetComponent<Rigidbody2D>();
        PlayerCollision = GetComponent<BoxCollider2D>();
        //ani = GetComponent<Animation>();
        player = this;
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Need better solution to getting the healthbar later
        animHealth = FindObjectOfType<UnityEngine.UI.Slider>().GetComponentInChildren<Animator>();

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
            isGround = Physics2D.Linecast(transform.position, groundcheck.position, 1 << LayerMask.NameToLayer("Ground"));

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
        
    }

    void FixedUpdate()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("RobotDeath"))
        {
            if (!isPaused)
            {
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
                    rb2d.AddForce(new Vector2(0f, jumpforce));
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

    IEnumerator jumpLag ()
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
}
