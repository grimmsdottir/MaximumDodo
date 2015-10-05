using UnityEngine;
using System.Collections;

public class PlayerShootScript : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject BulletPosition01;
	public GameObject BulletPosition02;


	public float shootDelay = 0.25f;
	float cooldownTimer = 0;





	// Use this for initialization
	void Start () {
		
		//Debug.Log ("Who have me : " + gameObject.name);
	}
	
	// Update is called once per frame
	void Update () 
	{
		cooldownTimer -= Time.deltaTime;
		if (Input.GetMouseButton (0) && cooldownTimer <= 0 && GameObject.Find ("Arm").GetComponent<SpriteRenderer> ().enabled == true)
		    //&& GameObject.Find ("Pistol").GetComponent<SpriteRenderer> ().enabled == false ) 
		{
			//Debug.Log ("ARMMM!");
			cooldownTimer = shootDelay;
			GameObject.Find ("Pistol").GetComponent<PlayerShootScript>().enabled = false;
			GameObject.Find ("Arm").GetComponent<PlayerShootScript>().enabled = true;
			//transform.position = GameObject.Find ("Arm").transform.position;
			//transform.rotation = GameObject.Find ("Arm").transform.rotation;


			Instantiate (bulletPrefab, transform.position, Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0.0f, 0.0f, 90.0f)));

		}

		else if (Input.GetMouseButton (0) && cooldownTimer <= 0 && GameObject.Find ("Pistol").GetComponent<SpriteRenderer> ().enabled == true)
		         //&& GameObject.Find ("Arm").GetComponent<SpriteRenderer> ().enabled == false) 
		{
			//Debug.Log ("PPISTOLLLL!");
			cooldownTimer = shootDelay;
			GameObject.Find ("Pistol").GetComponent<PlayerShootScript>().enabled = true;
			GameObject.Find ("Arm").GetComponent<PlayerShootScript>().enabled = false;



			//GameObject bullet01 = (GameObject)Instantiate (bulletPrefab);
			//bullet01.transform.position = BulletPosition01.transform.position;
			//bullet01.transform.rotation = BulletPosition01.transform.rotation;

			//GameObject bullet02 = (GameObject)Instantiate (bulletPrefab);
			//bullet02.transform.position = BulletPosition02.transform.position;
			//bullet02.transform.rotation = BulletPosition02.transform.rotation;


			//transform.position = GameObject.Find("Pistol").transform.position;
			//transform.rotation = GameObject.Find("Pistol").transform.rotation;

			Instantiate (bulletPrefab, BulletPosition01.transform.position, Quaternion.Euler(BulletPosition01.transform.rotation.eulerAngles - new Vector3(0.0f, 0.0f, 90.0f)));
			Instantiate (bulletPrefab, BulletPosition02.transform.position, Quaternion.Euler(BulletPosition02.transform.rotation.eulerAngles - new Vector3(0.0f, 0.0f, 90.0f)));



		}

	}


}
