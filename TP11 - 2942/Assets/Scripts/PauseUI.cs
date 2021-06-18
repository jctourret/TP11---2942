using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public void SetPause()
    {
        Time.timeScale = 0.0f;
        gameObject.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        //GameManager.Instance.ChangeScene("MainMenu");
    }
}