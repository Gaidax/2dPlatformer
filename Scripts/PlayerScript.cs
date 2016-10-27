using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public float speed;
    public float acceleration;
    public float jumpHeight;
    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask isGround;
    public LayerMask isWall;
    public float groundCheckRad;
    public float wallCheckRad;
    public GameController gameController;
    public float deadZone;

    private float player_input;
    private Rigidbody2D rigidbod;
    private SpriteRenderer spriteRen;
    private bool grounded;
    private bool walled;
    private bool doubleJumped;

	// Use this for initialization
	void Start () {
        rigidbod = GetComponent<Rigidbody2D>();
        spriteRen = GetComponent<SpriteRenderer>();

    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            doJump();
        }
   
    }

    private void wallJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && walled)
        {
            doJump();
        }
    }

    private void move()
    {
        player_input = Input.GetAxis("Horizontal");
        

        if (player_input > 0)
        {
            rigidbod.velocity = new Vector2(speed, rigidbod.velocity.y);
            spriteRen.flipX = false;

        } else if(player_input < 0)
        {
            rigidbod.velocity = new Vector2(-speed, rigidbod.velocity.y);
            spriteRen.flipX = true;
        }
    }

    private void doubleJump()
    {
        if (grounded || walled)
            doubleJumped = false;

        if (Input.GetKeyDown(KeyCode.Space) && !grounded && !doubleJumped)
        {
            doJump();
            doubleJumped = true;
        }

    }

    private void jumpMechanics()
    {
        doubleJump();
        jump();
        wallJump();
    }

    private void doJump()
    {
        rigidbod.velocity = new Vector2(rigidbod.velocity.x, jumpHeight);
    }

    private void fall()
    {
        if (gameObject.transform.position.y < deadZone)
        {
            gameObject.transform.position = gameController.CheckPoint.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spikes") && !grounded)
        {
            gameController.respawn();

        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            gameController.respawn();     
        }

        if (other.gameObject.CompareTag("Bonus"))
        {
            other.enabled = false;
            other.GetComponent<Renderer>().enabled = false;
            gameController.PointsValue++;
        }

    }

    // Update is called once per frame
    void Update () {
        jumpMechanics();
        move();
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRad, isGround);
        walled = Physics2D.OverlapCircle(wallCheck.position, wallCheckRad, isWall);
        fall();
    }

}
