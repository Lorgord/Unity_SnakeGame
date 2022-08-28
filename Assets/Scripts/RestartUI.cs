using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RestartUI : MonoBehaviour
{
    public TMP_Text MainText;
    public TMP_Text RestartText;
    public Image Image;
    public SnakeTail snake;
    public RestartButton button;
    private Color32 startColor = new Color32(0, 0, 0, 0);
    private Color32 panelColor = new Color32(0, 0, 0, 255);
    private Color32 textColor = new Color32(100, 0, 0, 255);
    private float time;
    private float fadeSpeed = 0.3f;

    private void Update()
    {
        if (snake.PlayerIsDead) {
            button.gameObject.SetActive(true);
            FadeUI();
        }

    }
    private void FadeUI()
    {
        time += Time.deltaTime;
        if (time < 4) {
            Image.color = Color.Lerp(startColor, panelColor, fadeSpeed * time);
            MainText.color = Color.Lerp(startColor, textColor, fadeSpeed * time);
        }
        else if (time < 6) {
            fadeSpeed = 0.6f;
            RestartText.color = Color.Lerp(startColor, textColor, fadeSpeed * (time - 4));
        }
        else
        {
            RestartText.color = Color.Lerp(textColor, startColor, fadeSpeed * (time - 6));
            if (time > 8) time = 4;
        }
    }

}
