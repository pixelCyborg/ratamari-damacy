using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TeamLeaf.CameraControls
{
    public class CameraFollow : MonoBehaviour
    {
        [Header("Control Values")]
        [SerializeField] Vector2 moveSpeed;
        [SerializeField] float minBoomAngle;
        [SerializeField] float maxBoomAngle;

        [Header("References")]
        [SerializeField] private Transform trackedObject;
        [SerializeField] private Transform cameraPivot;

        [SerializeField] private Vector3 debugEulers;
        
        private Camera cam;
        private Camera Cam
        {
            get
            {
                if (cam == null) cam = Camera.main;
                return cam;
            }
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            RotateCamera(x, y);
            transform.position = trackedObject.position;
        }

        private void LateUpdate()
        {
            Cam.transform.LookAt(trackedObject);
        }

        private void RotateCamera(float x, float y)
        {
            //cameraPivot.Rotate(new Vector3(y * -moveSpeed.y, x * moveSpeed.x, 0), Space.Self);

            Vector3 targetRot = cameraPivot.localEulerAngles;
            targetRot.x += (y * -moveSpeed.y);
            targetRot.y += (x * moveSpeed.x);

            targetRot.x = targetRot.x > 180f ? targetRot.x - 360f : targetRot.x;

            debugEulers = targetRot;
            if (targetRot.x > maxBoomAngle) targetRot.x = maxBoomAngle;
            if (targetRot.x < minBoomAngle) targetRot.x = minBoomAngle;
            cameraPivot.rotation = Quaternion.Euler(targetRot);
        }
    }
}
