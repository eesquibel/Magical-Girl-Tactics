using Assets.DataModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour, IAction {

    private ActionPointsController apController;
    private GridController gridController;

    private AttackObject Attack;
    private HealthController Target;

    public AttackObject[] AvailableAttacks;

    public int ActionPointCost
    {
        get
        {
            return Attack.ActionPointCost;
        }
    }

    private bool ActionValidate()
    {
        if (Attack == null)
        {
            return false;
        }

        if (Target == null)
        {
            return false;
        }

        GridController targetGrid = Target.gameObject.GetComponent<GridController>();

        if (targetGrid == null)
        {
            return false;
        }

        var distance = targetGrid.GridPosition - gridController.GridPosition;

        if (distance.magnitude > Attack.Range)
        {
            return false;
        }

        return true;
    }

    public bool CanDoAction()
    {
        return ActionValidate() && apController.CanDoAction(this);
    }

    public void SetTarget(HealthController t)
    {
        Target = t;
    }

    public void SetTarget(GameObject go)
    {
        HealthController healthController = go.GetComponent<HealthController>();
        SetTarget(healthController);
    }

    public void SetAttack(AttackObject a)
    {
        Attack = a;
    }

    public bool TryDoAction()
    {
        if (ActionValidate() && apController.TrySpendAP(this))
        {
            float hit = Random.Range(0f, 1f);
            if (hit < Attack.HitChange)
            {
                Target.Subtract(Attack.Damage);

                BroadcastMessage("OnAttackSuccess", new AttackMessage(Attack, Target));
                Target.gameObject.BroadcastMessage("OnAttackHit", new AttackMessage(Attack, this));
            }

            Target = null;
            Attack = null;

            return false;
        }
        else
        {
            return false;
        }
    }

    // Use this for initialization
    void Start () {
        Target = null;
        Attack = null;
        apController = GetComponent<ActionPointsController>();
        gridController = GetComponent<GridController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
