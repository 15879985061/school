using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform playerPos;
    public Transform cameraParentPos;
    public Transform cameraPos;
    public float rotateSpeed;


    void Start()
    {
        cameraPos.position = cameraParentPos.position + new Vector3(0, 2, -4);
    }
    void LateUpdate()
    {
        cameraParentPos.position = playerPos.position;

        float MouseX = Input.GetAxis("Mouse X");
        cameraParentPos.Rotate(new Vector3(0, MouseX * Time.deltaTime * rotateSpeed, 0));
    }

}
