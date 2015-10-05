using UnityEngine;
using System.Collections;

public class SwitchWeaponScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	
	{
		GameObject.Find ("Arm").GetComponent<SpriteRenderer> ().enabled = true;
		GameObject.Find ("Pistol").GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{

			GameObject.Find ("Arm").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("Pistol").GetComponent<SpriteRenderer> ().enabled = false;
		}

		else if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			GameObject.Find ("Arm").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Pistol").GetComponent<SpriteRenderer> ().enabled = true;
		}



	}
}
