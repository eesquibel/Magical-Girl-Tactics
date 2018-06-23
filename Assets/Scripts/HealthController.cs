using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

    public int Health = 100;

    public int MaxHealth = 100;

    public void Add(int health)
    {
        Health = Mathf.Clamp(Health + health, 0, MaxHealth);
    }

    public void Subtract(int health)
    {
        Add(-health);

        if (Health == 0)
        {
            gameObject.BroadcastMessage("OnDead");

        }
    }

    
        // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
