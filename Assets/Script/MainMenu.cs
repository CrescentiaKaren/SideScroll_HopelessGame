using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Easy_Button() {
        SceneManager.LoadSceneAsync("Level1");
    }

    public void Menu_Button() {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
