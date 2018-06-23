using Assets.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionPointsController : MonoBehaviour {

    public int ActionPoints = 10;

    public int MaxActionPoints = 30;

    public int APPerRound = 5;

    private UnityAction<TurnStartParameters> TurnStartListener;

    public bool CanDoAction(IAction action)
    {
        return CanDoAction(action.ActionPointCost);
    }

    public bool CanDoAction(int cost)
    {
        return ActionPoints >= cost;
    }

    public bool TrySpendAP(IAction action)
    {
        return TrySpendAP(action.ActionPointCost);
    }

    public bool TrySpendAP(int amount)
    {
        if (CanDoAction(amount))
        {
            ActionPoints -= amount;
            return true;
        } else
        {
            return false;
        }
    }

    private void Awake()
    {
        TurnStartListener = new UnityAction<TurnStartParameters>(OnTurnStart);
    }

    private void OnEnable()
    {
        EventManager.TurnStart.AddListener(TurnStartListener);
    }

    private void OnApplicationQuit()
    {
        if (EventManager.Instance)
        {
            EventManager.TurnStart.RemoveListener(TurnStartListener);
        }
    }

    private void OnDisable()
    {
        if (EventManager.Instance)
        {
            EventManager.TurnStart.RemoveListener(TurnStartListener);
        }
    }

    private void OnDestroy()
    {
        if (EventManager.Instance)
        {
            EventManager.TurnStart.RemoveListener(TurnStartListener);
        }
    }

    private void OnTurnStart(TurnStartParameters parameters)
    {
        if (parameters.TargetTag == gameObject.tag)
        {
            ActionPoints = Mathf.Clamp(ActionPoints + APPerRound, 0, MaxActionPoints);
        }
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
