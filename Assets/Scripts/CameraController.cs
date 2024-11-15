using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameController gameController;

    private float deltaX;

    void FixedUpdate()
    {
        deltaX = Mathf.Clamp((0.75f - (0.75f * Time.timeSinceLevelLoad / 30)), 0, 0.75f);

        if (gameController.isGameRunning)
        {
            transform.position = new Vector3(transform.position.x + deltaX, transform.position.y, transform.position.z);
        }
    }
}
