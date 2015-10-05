using UnityEngine;
using System.Collections;

public class PlayerBulletScript : MonoBehaviour 
{
    [HideInInspector] public int damage;
    public float timer = 1f;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        DestroySelfAfterTime();
	}

    void DestroySelfAfterTime()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealthManager>().giveDamage(damage);
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Enviroment"))
        {
            Destroy(this.gameObject);
        }
    }
}
