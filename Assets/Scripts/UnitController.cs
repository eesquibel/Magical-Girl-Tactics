using Assets.DataModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

    public Vector2 MenuOffset;

    private MovementController movement;
    private AttackController attackController;

    // Use this for initialization
    void Start () {
        movement = GetComponent<MovementController>();
        attackController = GetComponent<AttackController>();
	}
	
    public bool Move(Vector2 target)
    {
        movement.SetTarget(target);
        return movement.TryDoAction();
    }

    public bool Attack(HealthController target, AttackObject attack)
    {
        attackController.SetTarget(target);
        attackController.SetAttack(attack);
        return attackController.TryDoAction();
    }

    void OnMouseDown()
    {
        GameManager.Instance.gameObject.GetComponent<MenuController>().ActivateMenuOnUnit(this);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
