using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class MenuController : MonoBehaviour {

	public GameObject MenuCanvas;

    private UnitController currentUnit;

    public void ActivateMenuOnUnit(UnitController unit)
    {
        currentUnit = unit;
        Camera.main.GetComponentInParent<CameraController>().enabled = false;
        AutoCam ac = Camera.main.GetComponentInParent<AutoCam>();
        ac.enabled = true;
        ac.SetTarget(unit.transform);
        MenuCanvas.SetActive(true);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if( currentUnit != null )
        {
            RectTransform rt = MenuCanvas.GetComponent<RectTransform>();
            //Vector3 menuPoint = currentUnit.transform.position + (Vector3)currentUnit.MenuOffset;
            rt.anchoredPosition = Camera.main.WorldToScreenPoint(currentUnit.gameObject.transform.TransformPoint(currentUnit.gameObject.transform.position));
        }
	}
}
