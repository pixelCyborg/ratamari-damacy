using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private float gameTime = 600f;
    [SerializeField] private float winMass = 60f;
    [SerializeField] Rigidbody body;
    [SerializeField] Text timerText;

    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;


    [SerializeField] private float currentTime;
    private float origTime;
    private bool gameWin = false;
    private bool gameLose = false;

    void Start()
    {
        origTime = Time.time;
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    private void Update()
    {
        CheckPlayerMass();

        float timeElapsed = Time.time - origTime;
        currentTime = gameTime - timeElapsed;
        if (currentTime < 0f) currentTime = 0f;

        if(timerText != null)
        {
            TimeSpan t = TimeSpan.FromSeconds(currentTime);
            string timeString = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
            timerText.text = timeString;
        }

        if (currentTime <= 0f)
        {
            Lose();
            return;
        }
    }

    private void CheckPlayerMass()
    {
        if(body.mass >= winMass)
        {
            Win();
        }
    }

    private void Win()
    {
        if (gameWin || gameLose) return;
        gameWin = true;
        winScreen.SetActive(true);
    }

    private void Lose()
    {
        if (gameWin || gameLose) return;
        gameLose = true;
        loseScreen.SetActive(true);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
