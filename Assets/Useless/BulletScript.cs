using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour 
{
	public float moveSpeed = 1.0f;
	public bool isEnabled = false;

	public GameObject bulletPrefab;

	float aliveTimer = 0.0f;
	float aliveDuration = 2.0f;

	// Use this for initialization
	void Start () 
	{
		GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButton(0) && !isEnabled)
		{
			isEnabled = true;
			GetComponent<SpriteRenderer>().enabled = true;

			/*
			transform.position = GameObject.Find("Arm").transform.position;
			transform.rotation = GameObject.Find("Arm").transform.rotation;

			*/
		}

		if(isEnabled)
		{


			aliveTimer += Time.deltaTime;

			if(aliveTimer > aliveDuration)
			{
				isEnabled = false;
				aliveTimer = 0.0f;
				GetComponent<SpriteRenderer>().enabled = false;
			}
		}

	}
}
