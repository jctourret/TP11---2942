using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesKilledText : MonoBehaviour
{
    TextMeshProUGUI _text;
    int enemiesKilled = 0;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = enemiesKilled.ToString();
    }

    private void OnEnable()
    {
        EnemyDeath.onEnemyDeath += updateEnemiesKilled;
    }

    private void OnDisable()
    {
        EnemyDeath.onEnemyDeath -= updateEnemiesKilled;
    }

    void updateEnemiesKilled(int i)
    {
        enemiesKilled++;
        _text.text = enemiesKilled.ToString();
    }
}
