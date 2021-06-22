using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private Image energyBar;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text bombsText;
    [SerializeField] private TMP_Text enemiesKilled;
    [SerializeField] private PauseUI pause;
    public float playerEnergy;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
        }
    }

    public void SetPause()
    {
        pause.SetPause();
    }

    void UpdateEnergy()
    {
        energyBar.fillAmount = 1f / 100;
    }

    void UpdateScore()
    {
        scoreText.text = "0" + "pts";
    }

    void UpdateBombs()
    {
        bombsText.text = "0";
    }

    void UpdateEnemiesKilled()
    {
        enemiesKilled.text = "0";
    }
}
