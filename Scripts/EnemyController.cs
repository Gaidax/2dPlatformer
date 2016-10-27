using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float speed;
    public Transform SightStart;
    public Transform SightEnd;
    public Transform Stomp;
    public float stompCheckRad;
    public LayerMask isGround;
    public GameController gameController;

    private bool grounded;
    private Rigidbody2D rigidbod;
    private Transform transform;
    private SpriteRenderer spriteRen;
    // Use this for initialization
    void Start () {
        rigidbod = GetComponent<Rigidbody2D>();
        spriteRen = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();

        grounded = true;
    }
	

    private void move()
    {
            rigidbod.velocity = new Vector2(transform.localScale.x, 0)*speed;

        print(transform.localScale.x);
    }

    void FixedUpdate()
    {
        grounded = Physics2D.Linecast(
        SightStart.position,
        SightEnd.position,
        1 << LayerMask.NameToLayer("Ground"));

        if(grounded)
            move();

        if (!grounded)
            flip();

    }

    private void flip()
    {
        if (transform.localScale.x == 1)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }
}
