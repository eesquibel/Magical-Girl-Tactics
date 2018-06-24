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

	void OnMouseDown()
	{
		GameManager gm = GameManager.Instance;
		MenuController mc = gm.gameObject.GetComponent<MenuController>();
		mc.MenuCanvas.SetActive(true);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
