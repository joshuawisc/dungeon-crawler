using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform lookAt;
    public Transform cameraTransform;
    private Camera camera;
    private float cameraDistance = 15.0f ;
    

    // Start is called before the first frame update
    private void Start()
    {
        cameraTransform = transform;
        camera = Camera.main;

    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 direction = new Vector3(0 , 0 , -cameraDistance);
        
        cameraTransform.position = lookAt.position + direction;

    }
}
