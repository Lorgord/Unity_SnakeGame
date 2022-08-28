using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnakeTail : MonoBehaviour
{
    public List<GameObject> tailPartList = new List<GameObject>();
    public TMP_Text PartsAmountText;
    public GameObject tailPartPref;
    public ScoreManager scoreManager;
    public float tailOffsetSpeed = 0.02f;

    private float z;
    private int _health = 30;
    private bool _freeze;
    private bool _playerIsDead;
    public bool PlayerIsDead { get { return _playerIsDead; } }
    public bool Freeze { get { return _freeze; } set { _freeze = value; } }

    public int Health { get { return _health; } set { _health = value; } }


    private void Start()
    {
        tailPartList.Add(gameObject);

        for (int i = 0; i < _health; i++) {
            z += -0.5f;
            tailPartList.Add(Instantiate
                (tailPartPref,new Vector3 (0, 2, z), Quaternion.identity));
        }
        PartsAmountText.SetText(_health.ToString());
    }
    private void Update()
    {
        if (tailPartList.Count <= 0) return;
        if (_freeze) return;

        for (int i = 1; i < tailPartList.Count; i++) {
            Vector3 position = tailPartList[i].transform.position;
            Vector3 newPosition = tailPartList[i - 1].transform.position;

            position.x = Mathf.Lerp(position.x, newPosition.x, tailOffsetSpeed);
            position.z = Mathf.Lerp(position.z, newPosition.z, tailOffsetSpeed);

            tailPartList[i].transform.position = position;
            tailPartList[i].transform.LookAt(tailPartList[i - 1].transform);
        }

    }

    public void HealthUpdate(bool healthIncreace)
    {
        if (_health <= 0) { PlayerDead(); return; }

        if (healthIncreace) {
            int i = tailPartList.Count - 1;
            tailPartList.Add(Instantiate
                (tailPartPref, new Vector3(0, 2, tailPartList[i].transform.position.z - 5), Quaternion.identity));
        }
        if (!healthIncreace) {
            int i = tailPartList.Count - 1;
            Destroy(tailPartList[i]);
            tailPartList.Remove(tailPartList[i]);
        }
        PartsAmountText.SetText(_health.ToString());
    }
    public void PlayerDead()
    {
        scoreManager.SavePlayerStats();
        _playerIsDead = true;
        _health = 0;
        PartsAmountText.SetText(_health.ToString());
        for (int i = 1; i < tailPartList.Count; i++) { Destroy(tailPartList[i]); }
        tailPartList.Clear();
    }
}
