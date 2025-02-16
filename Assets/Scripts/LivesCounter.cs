using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    private float imageWidth = 100;
    private float imageOffset = -50;
    public int maxLives;
    private int lives;
    private RectTransform rect;
    [SerializeField] GameObject uiScripts;
    [SerializeField] GameObject antiLife;
    private RectTransform antiLifeRect;
    [SerializeField] private AudioClip soundFX;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        antiLifeRect = antiLife.GetComponent<RectTransform>();
        ResetLives();
    }

    public void RemoveLife()
    {
        lives--;
        Died();
        SetLifeDisplay();
    }

    public void ResetLives()
    {
        lives = maxLives;
        SetLifeDisplay();
    }

    private void Died()
    {
        if (lives <= 0)
        {
            uiScripts.GetComponent<PauseMenu>().Die();
            SoundFX.instance.PlaySound(soundFX, player.transform, 1);
        }
    }

    private void SetLifeDisplay()
    {
        // Displays remaining and lost lives
        rect.sizeDelta = new Vector2(imageWidth * lives, rect.sizeDelta.y);
        rect.anchoredPosition = new Vector2((imageOffset * lives) - 50, rect.anchoredPosition.y);

        antiLifeRect.sizeDelta = new Vector2(imageWidth * (maxLives - lives), rect.sizeDelta.y);
        antiLifeRect.anchoredPosition = new Vector2((-imageOffset * (maxLives - lives)) - 350, rect.anchoredPosition.y);
    }
}
