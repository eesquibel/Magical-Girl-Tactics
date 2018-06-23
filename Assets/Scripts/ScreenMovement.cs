using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMovement : MonoBehaviour {

    private Vector2 last;
    private GridController grid;

	// Use this for initialization
	void Start () {
        grid = GetComponent<GridController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (last != grid.GridPosition)
        {
            gameObject.transform.position = GameManager.Instance.Grid2World(grid.GridPosition);
        }
	}
}
