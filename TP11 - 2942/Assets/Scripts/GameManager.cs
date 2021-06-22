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

    private void onDisable()
    {
        PlayerController.onPlayerDeath -= toCredits;
        EnemyDeath.onEnemyDeath -= updateScore;
    }

    void updateScore()
    {

    }

    void toCredits()
    {
        ChangeScene("GameOver");
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
