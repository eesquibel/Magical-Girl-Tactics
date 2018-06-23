using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour {

    private bool movingCubie;

    public GameObject Cubie;

    public void MoveCubie()
    {
        movingCubie = !movingCubie;

        if (movingCubie)
        {
            
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var point = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var grid = GameManager.Instance.World2Grid(point);

            if (movingCubie)
            {
                DoMoveCubie(grid);
            }

            // Debug.Log("World " + grid);
        }
    }

    void DoMoveCubie(Vector2 target)
    {
        movingCubie = false;
        Cubie.GetComponent<CharacterController>().Move(target);
    }
}
