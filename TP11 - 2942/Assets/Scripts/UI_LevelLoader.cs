using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LevelLoader : MonoBehaviour
{
    public static UI_LevelLoader Instance { get; private set; }

    void Awake()
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

        gameObject.SetActive(false);
    }

    public void SetVisible(bool show)
    {
        gameObject.SetActive(show);
    }

    public void Update()
    {
        float loadingVal = LoaderManager.Instance.loadingProgress;

        if (LoaderManager.Instance.loadingProgress >= 1)
            SetVisible(false);
    }
}
