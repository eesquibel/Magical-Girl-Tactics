using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager gameManager;

    public static GameManager Instance
    {
        get
        {
            if (!gameManager)
            {
                gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (!gameManager)
                {
                    Debug.LogError("There needs to be one active GameManager script on a GameObject in your scene.");
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

    private void Init()
    {
        
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
        var offset = world - Origin;

        Debug.Log("Offset " + offset);

        var scale = offset;
        scale.x = scale.x / XScale;
        scale.y = scale.y / YScale;

        Debug.Log("Scale " + scale);

        scale.x = Mathf.Round(scale.x);
        scale.y = Mathf.Round(scale.y);

        return scale;
    }

    public Vector2 Grid2World(Vector2 grid)
    {
        var scale = new Vector2();
        scale.x = grid.x * XScale;
        scale.y = grid.y * YScale;

        var offset = scale + Origin;

        return offset;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
