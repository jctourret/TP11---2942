using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void PlayGame()
    {
        LoaderManager.Instance.LoadScene("Level1");
        UI_LevelLoader.Instance.SetVisible(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
