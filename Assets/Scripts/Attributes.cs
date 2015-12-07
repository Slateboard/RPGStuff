using UnityEngine;
using System.Collections;

public class Attributes : MonoBehaviour
{
   
   // Testing
   public int healthPoints;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void ModHealth(int value)
    {
        healthPoints += value;
    }
}
