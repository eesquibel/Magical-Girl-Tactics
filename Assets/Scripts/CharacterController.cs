using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    private MovementController movement;

	// Use this for initialization
	void Start () {
        movement = GetComponent<MovementController>();
		
	}
	
    public bool Move(Vector2 target)
    {
        movement.SetTarget(target);
        return movement.TryDoAction();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
