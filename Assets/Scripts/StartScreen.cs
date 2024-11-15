using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public void DisplayStartScreen()
    {
        gameObject.SetActive(true);
    }

    public void HideStartScreen()
    {
        gameObject.SetActive(false);
    }
}
