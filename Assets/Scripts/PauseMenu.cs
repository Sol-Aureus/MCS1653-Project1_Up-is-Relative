using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject deathMenu;
    private bool isPaused = false;
    private bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !isDead)
        {
            Pause();
        }
    }

    public void Die()
    {
        isDead = true;
        deathMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Pause()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0;
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
