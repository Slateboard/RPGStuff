using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attributes))]

public class P1Class : MonoBehaviour
{
    

   Attributes attributes;
    private int maxHP = 100;

    public Projectile bullet;
    public Projectile missile;
    public float fireRate = 0.5f;
    public float nextFire = 0.5f;

    public Transform shotSpawn;
    public Transform playerPosition;

    public int moveSpeed;
    private Vector3 movement;
    public Vector3 rotation;

    public Camera cameraObject;

	// Use this for initialization
	void Start ()
    {
         attributes = GetComponent<Attributes>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        FireWeapon();
        Movement();
    }

    public void ModHealth(int value)
    {
        attributes.healthPoints += value;

        if (attributes.healthPoints >= maxHP)
        {
            attributes.healthPoints = maxHP;
        }
        if (attributes.healthPoints <= 0)
        {
            attributes.healthPoints = 0;
        }
    }

    void Movement()
    {
        movement.x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        movement.y = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        rotation *= Time.deltaTime;

        gameObject.transform.position += movement;
       
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    transform.Rotate(0, 0, rotation);
        //}

       // gameObject.transform.Translate(movement);
      
        Vector3 screenPosition = cameraObject.WorldToScreenPoint(gameObject.transform.position);

    }

    void FireWeapon()
    {
        Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
        nextFire = Time.time + fireRate;

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
            nextFire = Time.time + fireRate;
        }

        if (Input.GetButton("Fire2") && Time.time > nextFire)
        {
            Instantiate(missile, shotSpawn.position, shotSpawn.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
