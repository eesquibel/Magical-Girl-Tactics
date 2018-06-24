using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class MenuController : MonoBehaviour {

	public GameObject UnitMenu;
    public GameObject GridDisplay;

    private GameObject activeMenu;
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
        activeMenu.SetActive(true);
    }

    public void HideMenu()
    {
        Camera.main.GetComponentInParent<AutoCam>().enabled = false;
        Camera.main.GetComponentInParent<CameraController>().enabled = true;
        activeMenu.SetActive(false);
    }

    public void MoveCurrentUnit()
    {
        if(currentUnit != null )
        {
            selectingMovement = true;
            HideMenu();
            GridDisplay.SetActive(true);
            inputWait = Time.time + 0.1f;
        }
    }

	void Start ()
    {
        activeMenu = Instantiate<GameObject>(UnitMenu);
        activeMenu.SetActive(false);
        activeMenu.transform.SetParent(GetComponentInChildren<Canvas>().transform);
        //var mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
        //if(mainCanvas != null)
        //{
        //    activeMenu.transform.SetParent(mainCanvas.transform);
        //}
	}

    void Update()
    {
        if (activeMenu.activeSelf)
        {
            var menuPoint = currentUnit.transform.position + (Vector3)currentUnit.MenuOffset;
            activeMenu.transform.position = Camera.main.WorldToScreenPoint(menuPoint);
            return;
        }
    }

    void FixedUpdate()
    {
        if (Time.time < inputWait)
        {
            return;
        }

        if(selectingMovement && Input.GetMouseButtonDown(0))
        {
            var point = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var grid = GameManager.Instance.World2Grid(point);
            currentUnit.Move(grid);
            GridDisplay.SetActive(false);
            selectingMovement = false;
        }
    }
}
