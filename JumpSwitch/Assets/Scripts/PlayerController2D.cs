using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class PlayerController2D : MonoBehaviour
{

    public float moveSpeed = 3f;
    public Camera mainCamera;
    Vector3 cameraPos;
    Transform t;
    // Use this for initialization
    void Start()
    {
        t = transform;

        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Moves Forward and back along z axis                 
        transform.Translate(Vector2.up * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed);

        //Moves Left and right along x Axis                          
        transform.Translate(Vector2.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);

        // Camera follow
        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
        }
    }
}
