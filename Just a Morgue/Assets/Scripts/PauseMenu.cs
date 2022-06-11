using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pause;

    void Start()
    {
        pause.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void PauseOn()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void PauseOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
