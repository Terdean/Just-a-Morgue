using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlotMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Application.LoadLevel("Game");
    }
}
