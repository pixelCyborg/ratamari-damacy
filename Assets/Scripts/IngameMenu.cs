using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour
{
    public static IngameMenu Instance;


    [SerializeField] private float fadeTime = 0.2f;
    private CanvasGroup canvasGroup;
    private bool showing;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        Hide();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Cancel")) {
            if (showing) Hide();
            else Show();
        }
    }

    public void Show()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        ToggleCanvasGroup(true);
        showing = true;
        Time.timeScale = 0f;
    }

    public void Hide()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ToggleCanvasGroup(false);
        showing = false;
        Time.timeScale = 1f;
    }

    private void ToggleCanvasGroup(bool show)
    {
        canvasGroup.alpha = show ? 1f : 0f;
        canvasGroup.interactable = show;
        canvasGroup.blocksRaycasts = show;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui Click", transform.position);
    }

    public void Quit()
    {
        Application.Quit();
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui Click", transform.position);
    }

    public bool Paused()
    {
        return showing;
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui Click", transform.position);
    }
}
