using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    Image _image;
    void Start()
    {
        _image = GetComponent<Image>(); 
    }
    private void OnEnable()
    {
        PlayerController.onPlayerDamage += updateEnergy;
    }

    private void OnDisable()
    {
        PlayerController.onPlayerDamage -= updateEnergy;
    }

    void updateEnergy(int energy)
    {
        _image.fillAmount = 1 / energy;
    }
}
