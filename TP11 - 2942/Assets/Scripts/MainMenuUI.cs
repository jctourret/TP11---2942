﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void PlayGame()
    {
        //GameManager.Instance.ChangeScene("GamePlay");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}