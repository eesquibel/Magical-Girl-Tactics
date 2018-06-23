using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour {

    public Vector2 GridPosition;

    public bool BlocksMovement;

    private void OnEnable()
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.RegisterGridObject(this);
        }
    }

    private void OnDisable()
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.DeregisterGridObject(this);
        }
    }
}
