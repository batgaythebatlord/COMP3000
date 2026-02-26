using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Runtime.Hosting;
using System.Threading;

public class dialogueSidebar : MonoBehaviour
{
    public static bool Display = false;
    public GameObject dialogueDisplay;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Display)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }
    }

    public void Hide()
    {
        Display = false;
        dialogueDisplay.SetActive(false);
    }

    void Show()
    {
        Display = true;
        dialogueDisplay.SetActive(true);
    }
}
