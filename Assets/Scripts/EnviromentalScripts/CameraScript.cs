using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;

	public GameObject Player;


	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () 
	
	{
		float posX = Mathf.SmoothDamp (transform.position.x, Player.transform.position.x, ref velocity.x, smoothTimeX);

		float posY = Mathf.SmoothDamp (transform.position.y, Player.transform.position.y, ref velocity.x, smoothTimeY);

		transform.position = new Vector3 (posX, posY, transform.position.z);
	}
}
