using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text GUICoinsText;
    public TMP_Text GUIScoreText;
    public TMP_Text MenuScoreText;
    public TMP_Text MenuCoinsText;
    private int _coins;
    private int _score;
    public int Score { get { return _score; } set { _score = value; } }
    public int Coins { get { return _coins; } set { _coins = value; } }

    private int loadedScore;
    private int loadedCoins;

    private void Awake()
    {
        LoadPlayerStats();
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            MenuScoreText.SetText("Best Score: " + loadedScore);
            MenuCoinsText.SetText("Coins: " + loadedCoins);
        }
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) {
            GUIScoreText.SetText("Score: " + _score.ToString());
            GUICoinsText.SetText("Coins: " + _coins.ToString());
        }
    }
    private void LoadPlayerStats()
    {
        loadedScore = PlayerPrefs.GetInt("Score");
        loadedCoins = PlayerPrefs.GetInt("Coins");
    }
    public void SavePlayerStats()
    {
        if (loadedScore < _score) {
            PlayerPrefs.SetInt("Score", _score);
        }
        PlayerPrefs.SetInt("Coins", loadedCoins + _coins);

        PlayerPrefs.Save();
    }
}
