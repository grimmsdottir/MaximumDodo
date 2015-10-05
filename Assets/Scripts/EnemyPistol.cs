using UnityEngine;
using System.Collections;

public class EnemyPistol : MonoBehaviour 
{
	public float engageDistance = 1.0f;
	public GameObject pistolBulletPrefab;

	public float shootDelay = 0.4f;

	float shootTimer = 0.0f;
	GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag ("Player");	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.GetComponent<EnemyPatrolScript>().startShooting) 
		{
			shootTimer += Time.deltaTime;
			if (DistanceToPlayer () < engageDistance) 
			{
				if(shootTimer > shootDelay)
				{
					Instantiate (pistolBulletPrefab, this.transform.position, qToPlayer());
					shootTimer = 0.0f;
				}
			}
		}

	
	}

	Quaternion qToPlayer ()
	{
		//First, get the heading to the palyer from self
		//This is a vector to the player
		Vector3 diff = player.transform.position - this.transform.position;
		//calculate the angle towards the target 
		float angle = Mathf.Atan2 (diff.y , diff.x)*Mathf.Rad2Deg ;
		angle += -90;
		Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
		
		return q;
	}

	float DistanceToPlayer()
	{
		return Vector3.Distance (this.transform.position, player.transform.position);
	}


}
