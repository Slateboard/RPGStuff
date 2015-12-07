using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attributes))]

public class P2Class : MonoBehaviour
{
    Attributes attributes;
    public int MoveSpeed;
    public Transform player;
    public Transform healing;
    private int maxHP = 100;

    enum AIMode {Normal, Advancing, Retreating};
    private AIMode CurrentAIState;


    // Use this for initialization
    void Start ()
    {
        CurrentAIState = AIMode.Normal;

        attributes = GetComponent<Attributes>();
    }
	
	// Update is called once per frame
	void Update ()
    {
       // attributes.ModHealth(1);

        switch (CurrentAIState)
        {
            case AIMode.Normal: UpdateNormal();
                break;

            case AIMode.Advancing: UpdateAdvancing();
                break;

            case AIMode.Retreating: UpdateRetreating();
                break;

            default: Debug.Log("Unknown AI State" + CurrentAIState);
                break;
        }

        DetermineAIState();
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

    void UpdateRetreating()
    {
        // Move Towards the Healing Area
        transform.position = Vector3.MoveTowards(transform.position, healing.position, MoveSpeed * Time.deltaTime);
       // transform.LookAt(healing);
    }

    void UpdateNormal()
    {
       
    }

    void UpdateAdvancing()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, MoveSpeed * Time.deltaTime);
       // transform.LookAt(player);
    }

    void DetermineAIState()
    {
        if (attributes.healthPoints <= 10)
        {
            CurrentAIState = AIMode.Retreating;
            Debug.Log("Current AI Mode is Retreating");
        }
        else if (attributes.healthPoints >= 80)
        {
            CurrentAIState = AIMode.Advancing;
            Debug.Log("Current AI Mode is Advancing");
        }
        else if (attributes.healthPoints >= maxHP)
        {
            CurrentAIState = AIMode.Normal;
            Debug.Log("Current AI Mode is Normal");
        }
    }
    

}
