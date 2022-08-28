using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PipeManager : MonoBehaviour
{
    public TMP_Text PipeFrontText;
    public GameObject door;
    private ScoreManager scoreManager;
    private Coin coinScript;
    private int _pipeHealth;
    public int PipeHealth { get { return _pipeHealth; } }

    private void Awake()
    {
        _pipeHealth = Random.Range(5, 30);
        PipeFrontText.SetText(_pipeHealth.ToString());
    }
    public void DoorHealthManager()
    {
        _pipeHealth--;
        if (_pipeHealth >= 0) {
            PipeFrontText.SetText(_pipeHealth.ToString());
        }
        if (_pipeHealth == 0) {
            GetCoinObj();
            Destroy(door);
        }
    }
    public void GetCoinObj()
    {
        Component coin = GetComponentInChildren(typeof(Coin));
        if (coin != null) {
            Coin coinObj = coin.GetComponent<Coin>();
            scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.Coins++;
            coinObj.DestroyCoin();
        }
    }
}
