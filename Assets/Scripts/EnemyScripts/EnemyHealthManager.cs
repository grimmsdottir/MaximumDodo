using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour 
{

	public int enemyHealth;
    public GameObject itemToDropPrefab;


	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (enemyHealth <= 0) 
		{
            Instantiate(itemToDropPrefab, this.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}

	public void giveDamage(int damageToGive)
	{
		enemyHealth -= damageToGive;
	}
}
