using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int _currentScore;
    int _highScore;

    private void OnEnable()
    {
        PlayerController.onPlayerDeath += toCredits;
        //Muerte enemigo
    }

    private void onDisable()
    {
        PlayerController.onPlayerDeath += toCredits;
        //Muerte enemigo
    }

    void updateScore()
    {

    }

    void toCredits()
    {

    }

    void toGameplay()
    {

    }
}
