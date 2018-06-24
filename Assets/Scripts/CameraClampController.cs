using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class CameraClampController : MonoBehaviour {

    public Vector2 clampWorldPointMin;
    public Vector2 clampWorldPointMax;

    private Camera myCamera;
    private AutoCam autoCam;
    private CameraController cameraController;

    private void Start()
    {
        myCamera = GetComponentInChildren<Camera>();
        autoCam = GetComponent<AutoCam>();
        cameraController = GetComponent<CameraController>();
    }

    void LateUpdate () {
        if (myCamera)
        {
            var bottomLeft = myCamera.ScreenToWorldPoint(Vector3.zero);
            var topRight = myCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

            var offset = new Vector3();

            if (bottomLeft.x < clampWorldPointMin.x)
            {
                offset.x = clampWorldPointMin.x - bottomLeft.x;
            } else if (topRight.x > clampWorldPointMax.x)
            {
                offset.x = clampWorldPointMax.x - topRight.x;
            }

            if (bottomLeft.y < clampWorldPointMin.y)
            {
                offset.y = clampWorldPointMin.y - bottomLeft.y;
            } else if (topRight.y > clampWorldPointMax.y)
            {
                offset.y = clampWorldPointMax.y - topRight.y;
            }

            if (offset != Vector3.zero)
            {
                transform.position += offset;

                if (offset.x != 0 && offset.y != 0)
                {
                    if (autoCam != null && autoCam.isActiveAndEnabled)
                    {
                        autoCam.enabled = false;

                        if (cameraController != null && cameraController.enabled == false)
                        {
                            cameraController.enabled = true;
                        }
                    }
                }

                return;
            }
        }
    }
}
