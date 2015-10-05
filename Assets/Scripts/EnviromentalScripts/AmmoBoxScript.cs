using UnityEngine;
using System.Collections;

public class AmmoBoxScript : MonoBehaviour 
{
    public int ammoType = 1;
    public int ammoToRestore = 25;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            coll.gameObject.GetComponent<PlayerScripts>().ChangeAmmo(ammoType, ammoToRestore);
            Destroy(this.gameObject);
        }
    }
}
