using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public int MoveSpeed;
    public int DamageValue;

    private P2Class P2Target;
    

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.up * Time.deltaTime * MoveSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<P2Class>().ModHealth(DamageValue);
        }
        
    }
}
