using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime;
using System.Threading;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class startMenu : MonoBehaviour
{
    public GameObject startScreen; 
    public GameObject charaSelect;

    void Start()
    {
        GoToStart();
    }

    //do summit with which chara
    public void PlayGame()
    {
        SceneManager.LoadScene("mainGame");
    }

    public void GoToChara()
    {
        startScreen.SetActive(false);
        charaSelect.SetActive(true);
    }

    public void GoToStart()
    {
        startScreen.SetActive(true);
        charaSelect.SetActive(false);
    }

    public void QuitMenu()
    {
        UnityEngine.Debug.Log("Quitting game...");
        UnityEngine.Application.Quit();
    }
}
