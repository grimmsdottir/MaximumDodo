using UnityEngine;
using System.Collections;

public class DestroyBulletScript : MonoBehaviour {

	public float timer = 1f;
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;

		if (timer <= 0) {
			Destroy (gameObject);
		}
	}
}
