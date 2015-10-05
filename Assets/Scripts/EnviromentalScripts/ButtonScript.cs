using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	public bool on;

	// Use this for initialization
	void Start () 
	{
		on = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if(on)
		{
			if(Input.GetKeyDown(KeyCode.W))
			{
			GameObject.Find ("Moving").GetComponent<MovingPlatform>().enabled = true;
			}
		}

	}



	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "PlayerIdle" )
		{
			on = true;


		}


	}

}
