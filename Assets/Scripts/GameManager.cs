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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
