using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{
    public GameObject linkedDoor;
    [HideInInspector] GameObject player;
    [HideInInspector] bool isPlayerInDoor = false;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.W) && isPlayerInDoor)
        {
            if (player != null)
            {
                player.gameObject.GetComponent<Transform>().position = linkedDoor.GetComponent<Transform>().position;
                isPlayerInDoor = false;
            }
                
        }
        //Debug.Log(isPlayerInDoor);
	}

    void LateUpdate()
    {
        isPlayerInDoor = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            isPlayerInDoor = true;
        }
    }
}
