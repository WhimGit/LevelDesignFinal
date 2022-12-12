using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrainManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject aboutPanel;
    public GameObject lastScene;
    public GameObject nextScene;

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LevelTwo()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level2");
    }

    public void NextScene()
    {
        lastScene.SetActive(false);
        nextScene.SetActive(true);
    }

    public void About()
    {
        menuPanel.SetActive(false);
        aboutPanel.SetActive(true);
    }

    public void Menu()
    {
        aboutPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
