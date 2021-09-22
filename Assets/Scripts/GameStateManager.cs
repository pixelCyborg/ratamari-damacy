using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    [SerializeField] private float gameTime = 600f;
    [SerializeField] private float winMass = 60f;
    [SerializeField] Rigidbody body;
    [SerializeField] Text timerText;

    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    private CanvasGroup winCanvasGroup;
    private CanvasGroup loseCanvasGroup;


    [SerializeField] private float currentTime;
    private float origTime;
    private bool gameWin = false;
    private bool gameLose = false;

    void Start()
    {
        origTime = Time.time;

        winCanvasGroup = winScreen.GetComponent<CanvasGroup>();
        loseCanvasGroup = loseScreen.GetComponent<CanvasGroup>();
        winCanvasGroup.alpha = 0f;
        loseCanvasGroup.alpha = 0f;

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

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        winCanvasGroup.DOFade(1f, 3f);
    }

    private void Lose()
    {
        if (gameWin || gameLose) return;
        gameLose = true;
        loseScreen.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        loseCanvasGroup.DOFade(1f, 3f);
    }

    public void LoadMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public bool GameEnded()
    {
        return gameLose || gameWin;
    }
}
