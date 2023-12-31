using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menus : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject deathScreen;
    AudioManager audioManager;
    AudioSource mainMusic;
    public GameObject pauseButton;
    public GameObject objectiveScreen;
    public TextMeshProUGUI finalGameTime;
    public GameObject title;
    public GameObject buttons;

    private void Start()
    {
        mainMusic = GetComponent<AudioSource>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        pauseButton.SetActive(true);
        mainMusic.Play();
        audioManager.Stop("Menu Music");
    }

    public void Play()
    {
        SceneManager.LoadScene("MainScene");
        mainMusic.Play();
        audioManager.Stop("Menu Music");
        pauseButton.SetActive(true);
        //Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        audioManager.Play("Menu Music");
        mainMusic.Pause();
        pauseScreen.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        deathScreen.SetActive(false);
        SceneManager.LoadScene("Main Menu");
        SceneManager.LoadScene("MainScene");
        pauseButton.SetActive(true);
    }
    public void DeathScreen()
    {
        Time.timeScale = 0;
        audioManager.Play("Menu Music");
        mainMusic.Pause();
        deathScreen.SetActive(true);
        pauseButton.SetActive(false);

        finalGameTime.text = "He survived " + GetComponent<GameManager>().gameTime.ToString("0") + " seconds in hell";
    }

    public void Objective()
    {
        objectiveScreen.SetActive(true);
        title.SetActive(false);
        buttons.SetActive(false);
    }

    public void QuitObjective()
    {
        objectiveScreen.SetActive(false);
        title.SetActive(true);
        buttons.SetActive(true);
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
