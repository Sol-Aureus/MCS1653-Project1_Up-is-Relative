using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    private float imageWidth = 100;
    public int maxLives;
    private int lives;
    private RectTransform rect;
    [SerializeField] GameObject uiScripts;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
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
        }
    }

    private void SetLifeDisplay()
    {
        rect.sizeDelta = new Vector2(imageWidth * lives, rect.sizeDelta.y);
    }
}
