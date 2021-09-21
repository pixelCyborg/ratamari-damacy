using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui Click", transform.position);
    }

    public void Quit()
    {
        Application.Quit();
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui Click", transform.position);
    }
}
