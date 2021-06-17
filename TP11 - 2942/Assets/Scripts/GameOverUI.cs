using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _resultText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _enemiesKilledText;

    void Start()
    {
        _resultText.text = "YOU ???";
        _scoreText.text = "Score: 0";
        _enemiesKilledText.text = "Enemies Killed: 0";
    }

    public void BackToMenu()
    {
        //GameManager.Instance.ChangeScene("MainMenu");
    }
}
