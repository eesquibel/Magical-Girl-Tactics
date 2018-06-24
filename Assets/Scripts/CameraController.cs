using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float moveSpeed = 1;

    private void LateUpdate()
    {
        var position = (Vector2)Input.mousePosition;

        var normalized = new Vector2
        {
            x = Mathf.InverseLerp(0, Screen.width, position.x),
            y = Mathf.InverseLerp(0, Screen.height, position.y)
        };

        // Mouse outside window
        if (normalized.y == 1 || normalized.x == 1 || normalized.y == 0 || normalized.x == 0)
        {
            return;
        }

        // Check Dead Zone
        if (normalized.x > .25f && normalized.x < .75f && normalized.y > .25f && normalized.y < .75f)
        {
            return;
        }
        
        var target = Camera.main.ScreenToWorldPoint(position);

        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * moveSpeed);
    }
}
