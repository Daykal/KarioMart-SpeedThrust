using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("UI")] public int currentLap = 1;
    [HideInInspector] public int currentLapP2 = 1;

    public TMP_Text theLapText;

    public GameObject gameOverUI;
    [Header("PauseMenu")] public bool gameIsPaused = false;
    public GameObject pauseUI;


    private void Awake()
    {
        Time.timeScale = 1f;
        Application.targetFrameRate = 60;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
    
    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        
    }
    
    
    
    
    
    
}
