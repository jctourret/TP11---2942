using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BombsText : MonoBehaviour
{
    TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        PlayerController.onBombFired +=updateBombText;
    }
    private void OnDisable()
    {
        PlayerController.onBombFired -= updateBombText;
    }
    void updateBombText(int bombsleft)
    {
        _text.text = bombsleft.ToString();
    }
}
