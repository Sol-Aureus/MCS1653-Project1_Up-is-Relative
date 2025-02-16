using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject deathMenu;
    [SerializeField] GameObject winMenu;
    private bool isPaused = false;
    private bool otherMenu = false;

    [SerializeField] private AudioClip soundFX;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !otherMenu)
        {
            Pause();
        }
    }

    public void Die()
    {
        otherMenu = true;
        deathMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Win()
    {
        otherMenu = true;
        winMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Pause()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0;
            SoundFX.instance.PlaySound(soundFX, transform, 1);
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Home()
    {
        SceneManager.LoadScene(0);

        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1;
    }
}
