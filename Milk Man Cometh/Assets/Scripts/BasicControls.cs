using UnityEngine;
using System.Collections;

public class BasicControls : MonoBehaviour {

    public static bool facingRight = true;
    public bool jump = false;

    public float moveForce = 365f;
    public float maxSpeed = 10f;
    public float jumpforce = 1000f;
    public Transform groundcheck;

    protected bool isGround = false;
    protected bool isGrounded = true;
    protected bool isCrouched = false;
    protected Animator anim;
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
        rb2d = GetComponent<Rigidbody2D>();
        PlayerCollision = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update ()
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

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));

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
