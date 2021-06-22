using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    int _currentScore;
    int _highScore;

    private void OnEnable()
    {
        PlayerController.onPlayerDeath += toCredits;
        EnemyDeath.onEnemyDeath += updateScore;
    }

    private void OnDisable()
    {
        PlayerController.onPlayerDeath -= toCredits;
        EnemyDeath.onEnemyDeath -= updateScore;
    }

    void updateScore(int score)
    {
        _currentScore += score;
    }

    void toCredits()
    {
        ChangeScene("GameOver");
        _highScore = _currentScore;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
