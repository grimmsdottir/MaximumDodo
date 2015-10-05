﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private PlayerScripts player;

	// Use this for initialization
	void Start () 
	{

		player = FindObjectOfType<PlayerScripts>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer()
	{
		Debug.Log ("respawn player");
		player.transform.position = currentCheckpoint.transform.position;
	}

}