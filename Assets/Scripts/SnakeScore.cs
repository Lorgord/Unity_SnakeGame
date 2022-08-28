using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScore : MonoBehaviour
{
    public ScoreManager scoreManager;
    private int _score;
    private void Update()
    {
        _score = Mathf.RoundToInt(gameObject.transform.position.z);
        scoreManager.Score = _score;
    }
}
