using UnityEngine;
using System.Collections;

public class PlayerScripts : MonoBehaviour 
{
    //Public Variables
        //Movement Control Variables
	public float moveSpeed = 1.0f;
	public float jumpForce = 15.0f;
    public LayerMask whatIsGround;
	    //Shooting Control Variables
	public Transform groundCheck;
    public Collider2D attackTrigger;

    //Private Variables
        //Movement Control Variables
	[HideInInspector] float groundCheckRadius = 0.1f;
    //[HideInInspector] LayerMask whatIsGround = 7;//the ground layer
	[HideInInspector] bool doubleJumped;    
    [HideInInspector] Rigidbody2D rb;
    [HideInInspector] bool grounded;
    [HideInInspector] bool glide;
    [HideInInspector] bool drop;
    [HideInInspector] float dropTimer = 0.0f;
    [HideInInspector] float dropDuration = 0.4f;
    [HideInInspector] float airTimer = 0.0f;
    [HideInInspector] float airDuration = 0.28f;
        //Shooting Control Variables
    [HideInInspector] bool meleeAttack = false;
    [HideInInspector] float attackTimer = 0.0f;
    [HideInInspector] float attackCd = 0.3f;
        //Life Manager Variables
    [HideInInspector] public int lives = 3;
    [HideInInspector] bool isInvulnarable = false;
    [HideInInspector] float invulnarableDuration = 0.25f;
    [HideInInspector] float invulnarableTimer = 0f;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		GameObject.Find ("AttackTrigger").GetComponent<SpriteRenderer>().enabled = false;


	}

	void FixedUpdate()
	{
        MovementControl();
        ShootingControl();
        InvulnarableFrames();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
    
    void ShootingControl()
    {
        if (Input.GetMouseButton(1) && !meleeAttack)
        {
            meleeAttack = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
            GameObject.Find("AttackTrigger").GetComponent<SpriteRenderer>().enabled = true;
        }

        if (meleeAttack)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                meleeAttack = false;
                attackTrigger.enabled = false;
                GameObject.Find("AttackTrigger").GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    void MovementControl()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


        //Player Movement

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
        }


        //Player Jump

        if (grounded)
        {
            airTimer = 0.0f;
            doubleJumped = false;
            glide = false;
        }


        if (glide)
        {

            rb.gravityScale = 1.0f;

        }
        else
        {
            rb.gravityScale = 5f;

        }


        if (Input.GetKeyDown(KeyCode.Space) && grounded && !Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0, 1000 * jumpForce * Time.deltaTime);


        }
        //Double Jump
        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            rb.velocity = new Vector2(0, 1000 * jumpForce * Time.deltaTime);
            doubleJumped = true;

        }

        if (Input.GetKey(KeyCode.Space) && doubleJumped)
        {

            airTimer += Time.deltaTime;

            if (airTimer > airDuration)
            {
                glide = true;


            }
            else
            {
                glide = false;

            }

        }
        else
        {
            glide = false;
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space) && grounded)
        {

            GetComponent<BoxCollider2D>().enabled = false;
            drop = true;
        }

        if (drop)
        {
            dropTimer += Time.deltaTime;

            if (dropTimer > dropDuration)
            {
                GetComponent<BoxCollider2D>().enabled = true;
                dropTimer = 0.0f;
                drop = false;
            }
        }
    }

    void InvulnarableFrames()
    {
        if(isInvulnarable)
        {
            invulnarableTimer += Time.deltaTime;
            if (invulnarableTimer > invulnarableDuration)
            {
                isInvulnarable = false;
                invulnarableTimer = 0;
            }
        }
    }

    public void Die()
    {
        if (!isInvulnarable)
        {
            LevelManager levelManager = FindObjectOfType<LevelManager>();
            isInvulnarable = true;
            lives--;
            //Debug.Log("Lives Remaining: " + lives);
            if (lives >= 0)
            {
                //respawn            
                levelManager.RespawnPlayer();
            }
            else
            {
                //game over
            }
        }
    }
}


