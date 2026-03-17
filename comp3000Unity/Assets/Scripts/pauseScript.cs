using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime;
using System.Threading;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class pauseScript : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
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
        Paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    void Pause()
    {
        Paused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("startMenu");
    }

    public void Quit()
    {
        UnityEngine.Debug.Log("Quitting game...");
        UnityEngine.Application.Quit();
    }
}