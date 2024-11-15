using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public int availableBubbles;

    private float bubbleMaxUptime = 4.0f;

    private float bubbleUpTime = 0.0f;

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (IsBubbleActivated())
        {
            bubbleUpTime += Time.deltaTime;

            if (bubbleUpTime > bubbleMaxUptime)
            {
                DeactivateBubble();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.CompareTag("Water") || collidedObject.CompareTag("EvilDuck"))
        {
            DeactivateBubble();
        }
    }

    public void ActivateBubble()
    {
        if (availableBubbles > 0)
        {
            this.gameObject.SetActive(true);
        }
    }

    public void DeactivateBubble() 
    {
        availableBubbles -= 1;
        bubbleUpTime = 0.0f;

        this.gameObject.SetActive(false);
    }

    public bool IsBubbleActivated()
    {
        return this.gameObject.activeInHierarchy;
    }
}
