using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using Assets.DataModels;
using Assets.Events;

public class EventManager : MonoBehaviour
{

    private Dictionary<string, UnityEvent> eventDictionary;

    private TurnStartEvent turnStart;

    private UnitDeadEvent unitDead;

    private static EventManager eventManager;

    private static bool _hasInit = false;

    public static EventManager Instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    if (_hasInit == false)
                    {
                        Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                    }
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    public static TurnStartEvent TurnStart
    {
        get
        {
            return Instance.turnStart;
        }
    }

    public static UnitDeadEvent UnitDead
    {
        get
        {
            return Instance.unitDead;
        }
    }

    void Init()
    {
        _hasInit = true;

        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }

        if (TurnStart == null)
        {
            turnStart = new TurnStartEvent();
        }

        if (unitDead == null)
        {
            unitDead = new UnitDeadEvent();
        }
    }

    private void OnEnable()
    {
        DontDestroyOnLoad(this);
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if (eventManager == null) return;
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
