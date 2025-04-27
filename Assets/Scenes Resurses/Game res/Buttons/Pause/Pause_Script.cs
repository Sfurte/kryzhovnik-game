using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Script : MonoBehaviour
{

    [SerializeField] private GameObject pausePanel; 

    public void OnButtonClick()
    {
        Time.timeScale = 0f;
        if (pausePanel != null)
            pausePanel.SetActive(true);
        Debug.Log("Игра на паузе");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        if (pausePanel != null)
            pausePanel.SetActive(false);
        Debug.Log("Игра продолжается");
    }
}
