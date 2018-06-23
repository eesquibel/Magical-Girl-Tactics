﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour, IAction {

    private ActionPointsController apController;

    private GridController gridController;

    private Vector2? target;
    
    public int MovementActionPointCost = 1;

    public int ActionPointCost
    {
        get
        {
            return MovementActionPointCost;
        }
    }

    public void SetTarget(Vector2 t)
    {
        target = t;
    }

    private bool ActionValidate()
    {
        if (target == null)
        {
            return false;
        }

        if (target == gridController.GridPosition)
        {
            return false;
        }

        if (GameManager.GridIsEmpty(target.Value, true) == false)
        {
            return false;
        }

        return true;
    }

    public bool CanDoAction()
    {
        return ActionValidate() && apController.CanDoAction(this);
    }

    public bool TryDoAction()
    {
        if (ActionValidate() && apController.TrySpendAP(this))
        {
            gridController.GridPosition = target.Value;
            target = null;
            return true;
        } else
        {
            return false;
        }
    }

    // Use this for initialization
    void Start () {
        target = null;
        apController = GetComponent<ActionPointsController>();
        gridController = GetComponent<GridController>();
        gridController.BlocksMovement = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
