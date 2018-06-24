using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float moveSpeed = 1;

    public Vector2 clampViewportMin;
    
    public Vector2 clampViewportMax;

    private void LateUpdate()
    {
        Vector3 target = Vector3.zero;

        if (Input.anyKey)
        {
            var move = new Vector3
            {
                x = Input.GetAxis("Horizontal"),
                y = Input.GetAxis("Vertical")
            };

            if (move == Vector3.zero)
            {
                return;
            }

            target = transform.position + move;
        }
        else
        {
            var position = (Vector2)Input.mousePosition;

            var normalized = new Vector2
            {
                x = Mathf.InverseLerp(0, Screen.width, position.x),
                y = Mathf.InverseLerp(0, Screen.height, position.y)
            };
            
            // Check Dead Zone
            if (normalized.x > .01f && normalized.x < .99f && normalized.y > .01f && normalized.y < .99f)
            {
                return;
            }

            target = Camera.main.ScreenToWorldPoint(position);
            target.z = 0;
        }

        var smoothTarget = Vector3.Lerp(transform.position, target, Time.deltaTime * moveSpeed);
        smoothTarget.x = Mathf.Clamp(smoothTarget.x, clampViewportMin.x, clampViewportMax.x);
        smoothTarget.y = Mathf.Clamp(smoothTarget.y, clampViewportMin.y, clampViewportMax.y);

        transform.position = smoothTarget;
    }
}
