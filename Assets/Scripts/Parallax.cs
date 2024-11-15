using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPosition;

    private Camera mainCamera;

    public float parallaxMagnitude;

    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = transform.position.x;

        mainCamera = FindObjectOfType<Camera>();
    }

    void FixedUpdate()
    {
        float temp = mainCamera.transform.position.x * (1 - parallaxMagnitude);
        float distance = mainCamera.transform.position.x * parallaxMagnitude;

        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        if (temp > startPosition + length)
        {
            startPosition += length;
        }
        else if (temp < startPosition - length)
        {
            startPosition -= length;
        }
    }
}
