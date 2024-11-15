using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilDuck : MonoBehaviour
{
    private Camera mainCamera;

    private GameController gameController; 

    private float cameraXPosition;

    private float cameraOrthographicSize;

    private float cameraAspect;

    private float spawnInterval = 1.5f;

    private float timePassed = 0.0f;

    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        gameController = FindObjectOfType<GameController>();

        cameraXPosition = mainCamera.transform.position.x;
        cameraOrthographicSize = mainCamera.orthographicSize;
        cameraAspect = mainCamera.aspect;

        SpawnOffScreen();
    }

    void Update()
    {
        if (gameController.isGameRunning)
        {
            timePassed += Time.deltaTime;

            if (timePassed > spawnInterval)
            {
                SpawnAtCameraEdge();

                timePassed = 0.0f;
            }
        }

        cameraXPosition = mainCamera.transform.position.x;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.CompareTag("Bubble"))
        {
            SpawnOffScreen();
        }
    }

    private void SpawnOffScreen()
    {
        transform.position = new Vector3(-6.0f, -6.0f, transform.position.z);
    }

    private void SpawnAtCameraEdge()
    {
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            transform.position = new Vector3(cameraXPosition + (cameraOrthographicSize * cameraAspect), Random.Range(-3.5f, 3.5f), transform.position.z);
        }
    }
}
