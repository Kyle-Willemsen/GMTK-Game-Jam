using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject deathScreen;
    AudioManager audioManager;
    AudioSource music;

    private void Start()
    {
        music = GetComponent<AudioSource>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void Resume()
    {
        audioManager.Stop("Menu Music");
        music.Play();
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void Pause()
    {
        audioManager.Play("Menu Music");
        music.Pause();
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void LoadLevel1()
    {
        pauseScreen.SetActive(false);
        deathScreen.SetActive(false);
        SceneManager.LoadScene("Main Menu");
        SceneManager.LoadScene("MainScene");
    }
    public void DeathScreen()
    {
        audioManager.Play("Menu Music");
        music.Pause();
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
