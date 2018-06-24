using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMenuController : MonoBehaviour {
    
    public void Move()
    {
        GameManager.Instance.gameObject.GetComponent<MenuController>().MoveCurrentUnit();
    }

    public void Attack()
    {

    }

    public void Defend()
    {

    }

    public void Item()
    {

    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
