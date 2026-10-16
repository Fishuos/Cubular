using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraObject;
    public Transform cube;

    public float cameraX;
    public float cameraZ;
    // Update is called once per frame
    void Update()
    {
        cameraObject.position = new Vector3( cube.position.x + cameraX , cameraObject.position.y, cube.position.z + cameraZ);
    }
}
