using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    //public float zoomSpeed = 4f;
    //public float minZoom = 5f;
    //public float maxZoom = 15f;
    public float pitch = 1f;
    public float yawSpeed = 100f;


    private float currentZoom = 5f;
    private float currentYaw = 0f;


    private void Start()
    {
        offset.Set(0f, -1f, -1.2f);
    }
    // Update is called once per frame 
    void Update()
    {
        //    currentZoom -= Input.GetAxis("Mouth ScrollView") * zoomSpeed;   //currently Mouth ScrollView cannot be setup
        //    currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom); 
        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    // LateUpdate is rightafter Update
    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
        transform.RotateAround(target.position, Vector3.up,currentYaw);
    }
}
