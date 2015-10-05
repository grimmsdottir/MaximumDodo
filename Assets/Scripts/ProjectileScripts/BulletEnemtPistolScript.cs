using UnityEngine;
using System.Collections;

public class BulletEnemtPistolScript : MonoBehaviour {

	public float aliveDuration = 2.0f;
	public float moveSpeed = 10.0f;

	float aliveTimer = 0.0f;
	GameObject player;
	Vector3 direction;

	// Use this for initialization
	void Start () 
	{
		/*
		player = GameObject.Find ("Player");
		if (player.transform.position.x < this.transform.position.x) {
			direction = Vector3.left;
		} else 
		{
			direction = Vector3.right;
		}
		*/
			
	}
	
	// Update is called once per frame
	void Update () 
	{

		//transform.Translate(direction * moveSpeed * Time.deltaTime);
		transform.Translate (Vector3.up);

		aliveTimer += Time.deltaTime;

        if (aliveTimer > aliveDuration)
            Destroy(gameObject);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerScripts>().Die();

        }
    }
}
