using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject deathScreen;
    AudioManager audioManager;
    AudioSource mainMusic;

    private void Start()
    {
        mainMusic = GetComponent<AudioSource>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void Resume()
    {
        audioManager.Stop("Menu Music");
        mainMusic.Play();
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("MainScene");
        mainMusic.Play();
        audioManager.Stop("Menu Music");
        //Time.timeScale = 1;
    }

    public void Pause()
    {
        audioManager.Play("Menu Music");
        mainMusic.Pause();
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void Retry()
    {
        pauseScreen.SetActive(false);
        deathScreen.SetActive(false);
        SceneManager.LoadScene("Main Menu");
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }
    public void DeathScreen()
    {
        audioManager.Play("Menu Music");
        mainMusic.Pause();
        Time.timeScale = 0;
        deathScreen.SetActive(true);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
