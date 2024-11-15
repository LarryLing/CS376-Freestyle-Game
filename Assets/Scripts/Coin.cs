using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue;

    private Camera mainCamera;

    private float cameraXPosition;

    private float cameraOrthographicSize;

    private float cameraAspect;

    public GameController gameController;

    public AudioSource audioSource;

    public AudioClip coinAudio;

    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();

        cameraXPosition = mainCamera.transform.position.x;
        cameraOrthographicSize = mainCamera.orthographicSize;
        cameraAspect = mainCamera.aspect;

        SpawnAtRandomLocation();
    }

    void Update()
    {
        cameraXPosition = mainCamera.transform.position.x;
    }

    void OnBecameInvisible()
    {
        SpawnAtCameraEdge();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.CompareTag("Duck"))
        {
            gameController.SetCoinsCollected(gameController.GetCoinsCollected() + coinValue);

            SpawnAtCameraEdge();

            audioSource.PlayOneShot(coinAudio);
        }
        else if (collidedObject.CompareTag("Bubble"))
        {
            SpawnAtCameraEdge();
        }
    }

    private void SpawnAtRandomLocation()
    {
        transform.position = new Vector3(Random.Range(-3.0f, 8.0f), Random.Range(-3.5f, 3.5f), transform.position.z);
    }

    private void SpawnAtCameraEdge()
    {
        transform.position = new Vector3(cameraXPosition + (cameraOrthographicSize * cameraAspect), Random.Range(-3.5f, 3.5f), transform.position.z);
    }
}
