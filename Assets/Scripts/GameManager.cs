﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager gameManager;

    private static bool _hasInit;

    public static GameManager Instance
    {
        get
        {
            if (!gameManager)
            {
                gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (!gameManager)
                {
                    if (!_hasInit)
                    {
                        Debug.LogError("There needs to be one active GameManager script on a GameObject in your scene.");
                    }
                }
                else
                {
                    gameManager.Init();
                }
            }

            return gameManager;
        }
    }

    public Vector2 Origin;

    public float XScale;
    public float YScale;

    private List<GridController> gridGameObjects;

    private void Init()
    {
        _hasInit = true;
        gridGameObjects = new List<GridController>();
    }

    public static bool GridIsEmpty(Vector2 position, bool checkBlockMovement = false)
    {
        // All Inert Controllers
        var inertControllers = FindObjectsOfType<GridController>();
        if (inertControllers.Any(controller => controller.GridPosition == position && checkBlockMovement && controller.BlocksMovement))
        {
            return false;
        }

        return true;
    }

    public Vector2 World2Grid(Vector2 world)
    {
        var offset = world - Origin + new Vector2(-XScale / 2, YScale / 2);
        
        var scale = offset;
        scale.y = scale.y / YScale;

        // Debug.Log("World " + world + ", Offset " + offset + ", Scale " + scale);

        var grid = new Vector2
        {
            y = Mathf.Round(scale.y)
        };

        var xIncline = (offset.y - (grid.y * YScale) + YScale / 2) / YScale;

        var rowXOffset = (grid.y * (XScale / 2));

        scale.x = (scale.x + rowXOffset) / XScale;

        grid.x = Mathf.Round(scale.x + Mathf.Lerp(0, XScale, xIncline));
        
        return grid;
    }

    public Vector2 Grid2World(Vector2 grid)
    {
        var scale = new Vector2
        {
            x = grid.x * XScale,
            y = grid.y * YScale
        };

        var rowXOffset = new Vector2((grid.y) * (XScale / 2), 0);
        var offset = scale + Origin - rowXOffset;

        return offset;
    }

    public void RegisterGridObject(GridController gridController)
    {
        gridGameObjects.Add(gridController);
    }

    public void DeregisterGridObject(GridController gridController)
    {
        if (gridGameObjects.Contains(gridController))
        {
            gridGameObjects.Remove(gridController);
        }
    }

    public GridController GetObjectAtGrid(Vector2 grid)
    {
        return gridGameObjects.Where(gridController => gridController.GridPosition == grid).FirstOrDefault();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
