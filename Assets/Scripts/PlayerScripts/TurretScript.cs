using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour 
{
        //Pistol Variables
    public GameObject pistolBulletPrefab;
    public int pistolBulletDamage;
    public float pistolBulletSpeed;
    public float pistolRefireTime;
    [HideInInspector] float pistolReloadTimer;
        //Machinegun Variables
    public GameObject machinegunBulletPrefab;
    public int machinegunBulletDamage;
    public float machinegunBulletSpeed;
    public float machinegunRefireTime;
    [HideInInspector] float machiengunReloadTimer;
        //Shooting Variables
    [HideInInspector] GameObject projectile;
    [HideInInspector] Rigidbody2D projectileRB2D;
        //Player Reference
    [HideInInspector] GameObject player;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.Find("PlayerIdle");
	}
	
	// Update is called once per frame
	void Update () 
    {
        Aim();
        Reloading();
	}

    void Aim()
    {
        Vector3 playerScreenPos = new Vector3(Screen.width, Screen.height, 0.0f) / 2.0f;

        Vector3 mousPos = Input.mousePosition - playerScreenPos;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 5.0f, Mathf.Atan2
    (Input.mousePosition.y - playerScreenPos.y, Input.mousePosition.x - playerScreenPos.x) * Mathf.Rad2Deg));
    }

    void Reloading()
    {
        if (pistolReloadTimer <= pistolRefireTime)
        {
            pistolReloadTimer += Time.deltaTime;
        }

        if (machiengunReloadTimer <= machinegunRefireTime)
        {
            machiengunReloadTimer += Time.deltaTime;
        }
    }

    public void ShootWeapon(int weaponToUse)
    {
        Quaternion qToTarget = Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0.0f, 0.0f, 90.0f));
        switch (weaponToUse)
        {
            //Pistol
            case 0:
                if (pistolReloadTimer > pistolRefireTime)
                {
                    pistolReloadTimer = 0;
                    //player.GetComponent<PlayerScripts>().weaponAmmo[0]--;
                    projectile = Instantiate(pistolBulletPrefab, transform.position, qToTarget) as GameObject;
                    projectile.GetComponent<PlayerBulletScript>().damage = pistolBulletDamage;
                    projectileRB2D = projectile.GetComponent<Rigidbody2D>();
                    projectileRB2D.velocity = qToTarget * Vector2.up * pistolBulletSpeed;
                }
                break;                
            //Machinegun
            case 1:
                if (machiengunReloadTimer > machinegunRefireTime)
                {
                    machiengunReloadTimer = 0;
                    player.GetComponent<PlayerScripts>().ChangeAmmo(1, -1);
                    projectile = Instantiate(machinegunBulletPrefab, transform.position, qToTarget) as GameObject;
                    projectile.GetComponent<PlayerBulletScript>().damage = machinegunBulletDamage;
                    projectileRB2D = projectile.GetComponent<Rigidbody2D>();
                    projectileRB2D.velocity = qToTarget * Vector2.up * pistolBulletSpeed;
                }
                break;
        }
    }
}
