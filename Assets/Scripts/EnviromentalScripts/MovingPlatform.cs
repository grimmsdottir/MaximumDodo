using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	//private float xStartPosition = 0;
	private float yStartPosition = 0;
	private Vector3 m_velocity;
	
	
	// Use this for initialization
	void Start () 
	{

		m_velocity = new Vector3 (0.0f, 0.05f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.y >= yStartPosition + 5f) 
		{
			m_velocity = new Vector3 (0.0f, -0.05f, 0.0f);





			
		} 

		else if (transform.position.y <= yStartPosition - 0.05f) 
		{
			m_velocity = new Vector3 (0.0f, 0.05f , 0.0f);
		}
		
		
		
		
		Vector3 position = transform.position;
		
		
		
		transform.position = position + m_velocity;
	}
}




/*
			if ((transform.position.y <= yStartPosition - 2.47f) && (transform.position.x >= xStartPosition + 2.47f)) 
			{
				m_velocity = new Vector3 (-0.05f, 0.0f, 0.0f);
				
				if ((transform.position.x >=  -5f) && (transform.position.y <= yStartPosition - 2.47f)) 
				{
					m_velocity = new Vector3 (0f, 0.5f, 0.0f);
				}
			}
			*/
