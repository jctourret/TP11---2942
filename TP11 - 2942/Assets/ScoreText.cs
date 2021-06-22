using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ScoreText : MonoBehaviour
{
    TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        EnemyDeath.onEnemyDeath += updateScore;
    }
    private void OnDisable()
    {
        EnemyDeath.onEnemyDeath -= updateScore;
    }
    void updateScore(int score)
    {
        _text.text = score + "Pts";
    }
}
