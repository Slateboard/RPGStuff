using UnityEngine;
using System.Collections;

public class HealingArea : MonoBehaviour
{
    public P1Class P1Character;
    public P2Class P2Character;

    bool P1Healing = false;
    bool P2Healing = false;


	// Use this for initialization
	void Start ()
    {
        GameObject P1 = GameObject.Find("Cube1");
        GameObject P2 = GameObject.Find("Cube2");
        P1Character = P1.GetComponent<P1Class>();
        P2Character= P2.GetComponent<P2Class>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (P1Healing)
        {
            P1Character.ModHealth(1);
        }
        if (P2Healing)
        {
            P2Character.ModHealth(1);
        }
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            P1Healing = true;
            
        }

        if (other.tag == "Enemy")
        {
            P2Healing = true;
            
        }

        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            P1Healing = false;

        }

        if (other.tag == "Enemy")
        {
            P2Healing = false;

        }
    }
}
