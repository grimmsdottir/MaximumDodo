using UnityEngine;
using System.Collections;

public class EnemyPatrolScript : MonoBehaviour {

	public bool doesPatrol = true;
	public bool patrolRight = true;
	public bool doesEngage = true;


	public float moveSpeed = 1.0f;	
	public float detectDistance = 1.0f;
	[HideInInspector] public bool startShooting = false;


	GameObject player;
	bool isAlert = false;
	bool playerToTheRight = false;
	CircleCollider2D colliderRef;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag ("Player");
		colliderRef = this.GetComponent<CircleCollider2D> ();
		doesPatrol = true;
		patrolRight = true;
		doesEngage = true;



	}
	
	// Update is called once per frame
	void Update () 
	{
		if (doesPatrol && !isAlert) 
			Patrol ();
		if (!isAlert) 
		{
			DetectPlayer ();
		} 
		else 
		{
			ChargePlayer();
		}

	
	}

	void DetectPlayer ()
	{
		if (DistanceToPlayer() < detectDistance) 
		{
			isAlert = true;
		}
		
	}

	float DistanceToPlayer()
	{
		return Vector3.Distance (this.transform.position, player.transform.position);
	}	

	void Patrol()
	{
		var x = this.transform.position.x;
		if (patrolRight)
			x += moveSpeed * Time.deltaTime;
		else 
			x += moveSpeed * Time.deltaTime * -1;
		this.transform.position = new Vector3 (x, this.transform.position.y,0);
        /*
        if (patrolRight)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * moveSpeed);
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * moveSpeed);
        }
         */
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "PatrolFlag") 
		{
			patrolRight = !patrolRight;
		}
	}

	void ChargePlayer()
	{	
		startShooting = true;

		if (doesEngage)
		{
			var x = this.transform.position.x;
			
			if (player.transform.position.x > this.transform.position.x) {
				playerToTheRight = true;
			} else {
				playerToTheRight = false;
			}
			
			if (playerToTheRight) {
				x += moveSpeed * Time.deltaTime;
				
			} else {
				x += moveSpeed * Time.deltaTime * -1;
			}		
			this.transform.position = new Vector3 (x, this.transform.position.y, 0);
		}

	}
}
