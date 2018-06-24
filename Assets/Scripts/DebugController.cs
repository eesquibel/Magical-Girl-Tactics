using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour {

    private bool movingCubie;
    private bool cubieAttacking;

    public GameObject Cubie;

    public void MoveCubie()
    {
        movingCubie = !movingCubie;

        if (movingCubie)
        {
            
        }
    }

    public void CubieAttack()
    {
        cubieAttacking = true;
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
            var target = GameManager.Instance.GetObjectAtGrid(grid);

            if (movingCubie)
            {
                DoMoveCubie(grid);
            }

            if (cubieAttacking)
            {
                DoCubieAttack(target);
            }
            // Debug.Log("World " + grid);
        }
    }

    void DoMoveCubie(Vector2 target)
    {
        movingCubie = false;
        Cubie.GetComponent<UnitController>().Move(target);
    }

    void DoCubieAttack(GridController target)
    {
        cubieAttacking = false;

        if (target)
        {
            var healthController = target.GetComponent<HealthController>();
            var attacks = Cubie.GetComponent<AttackController>().AvailableAttacks;
            int i = Random.Range(0, attacks.Length);

            Cubie.GetComponent<UnitController>().Attack(healthController, attacks[i]);
        }
    }
}
