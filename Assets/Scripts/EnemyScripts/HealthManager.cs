using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

	public int playerHealth;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerHealth <= 0) 
		{
			Destroy (gameObject);
		}
	}
	
	public void giveDamage(int damageToGive)
	{
		playerHealth -= damageToGive;
	}
}
