using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    public GameController gameController;

    private float targetYPosition;

    float yVelocity = 0.0f;

    public AudioSource audioSource;

    public AudioClip coinAudio;

    public AudioClip tripleCoinAudio;

    public Bubble bubble;

    private float deltaX;

    void Start()
    {
        targetYPosition = transform.position.y;
    }

    void FixedUpdate()
    {
        deltaX = Mathf.Clamp((0.75f - (0.75f * Time.timeSinceLevelLoad / 30)), 0, 0.75f);

        if (gameController.isGameRunning)
        {
            if (deltaX > 0)
            {
                MoveDuck();
                ActivateBubble();
            }
            else
            {
                bubble.DeactivateBubble();

                targetYPosition = -4.5f;

                float newYPosition = Mathf.SmoothDamp(transform.position.y, targetYPosition, ref yVelocity, 0.25f);

                transform.position = new Vector3(transform.position.x + deltaX, newYPosition, transform.position.z);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.CompareTag("Water") || collidedObject.CompareTag("EvilDuck"))
        {
            gameController.GameOver();
        }
    }

    private void MoveDuck()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetYPosition = worldPosition.y;
        }

        float newYPosition = Mathf.SmoothDamp(transform.position.y, targetYPosition, ref yVelocity, 0.25f);

        newYPosition = Mathf.Clamp(newYPosition, -4.0f, 4.0f);

        transform.position = new Vector3(transform.position.x + deltaX, newYPosition, transform.position.z);
    }

    private void ActivateBubble()
    {
        if (Input.GetKey(KeyCode.Space) && !bubble.IsBubbleActivated())
        {
            bubble.ActivateBubble();
        }
    }
}
