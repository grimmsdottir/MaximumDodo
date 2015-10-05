using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthUILifeImageScript : MonoBehaviour 
{
    public int lifeNumber;
    GameObject player;
    bool isNeedUpdate = true;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.Find("PlayerIdle");	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isNeedUpdate)
        {
            int playerLife = player.GetComponent<PlayerScripts>().lives;
            if (playerLife < lifeNumber)
            {
                this.gameObject.GetComponent<Image>().enabled = false;
                isNeedUpdate = false;
            }
        }
    }
}
