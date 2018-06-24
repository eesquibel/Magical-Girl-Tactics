using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class MenuController : MonoBehaviour {

	public GameObject MenuCanvas;

    private UnitController currentUnit;
    private float inputWait = 0.0f;
    private bool selectingMovement = false;

    public void ActivateMenuOnUnit(UnitController unit)
    {
        currentUnit = unit;
        Camera.main.GetComponentInParent<CameraController>().enabled = false;
        AutoCam ac = Camera.main.GetComponentInParent<AutoCam>();
        ac.enabled = true;
        ac.SetTarget(unit.transform);
        MenuCanvas.SetActive(true);
    }

    public void HideMenu()
    {
        Camera.main.GetComponentInParent<AutoCam>().enabled = false;
        Camera.main.GetComponentInParent<CameraController>().enabled = true;
        MenuCanvas.SetActive(false);
    }

    public void MoveCurrentUnit()
    {
        if(currentUnit != null )
        {
            selectingMovement = true;
            HideMenu();
            inputWait = Time.time + 0.1f;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (currentUnit == null)
        {
            return;
        }

        if(MenuCanvas.activeSelf)
        {
            var rt = MenuCanvas.GetComponent<RectTransform>();
            var menuPoint = currentUnit.transform.position + (Vector3)currentUnit.MenuOffset;
            MenuCanvas.transform.position = Camera.main.WorldToScreenPoint(menuPoint);
            return;
        }

        if(Time.time < inputWait)
        {
            return;
        }

        if(selectingMovement && Input.GetMouseButtonDown(0))
        {
            var point = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var grid = GameManager.Instance.World2Grid(point);
            currentUnit.Move(grid);
            selectingMovement = false;
        }
    }
}
