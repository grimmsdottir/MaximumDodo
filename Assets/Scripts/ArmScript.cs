using UnityEngine;
using System.Collections;

public class ArmScript : MonoBehaviour {



	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 playerScreenPos = new Vector3 (Screen.width, Screen.height, 0.0f) / 2.0f;

		Vector3 mousPos = Input.mousePosition - playerScreenPos;    
		transform.rotation = Quaternion.Euler (new Vector3 (0.0f, 5.0f, Mathf.Atan2 
	(Input.mousePosition.y - playerScreenPos.y, Input.mousePosition.x - playerScreenPos.x) * Mathf.Rad2Deg));




	}
}
