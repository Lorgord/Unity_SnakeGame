using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public SnakeControls Snake;
    public SnakeTail SnakeTail;
    public AudioSource GameAudio;
    public AudioSource DeathAudio;
    private LevelGeneration LevelGeneration;
    private Vector3 _mouseStartPosition;
    public float sensitivity = 0.003f;
    private float volume = 1;
    private bool allAudioPlayed;

    private void Awake()
    {
        LevelGeneration = FindObjectOfType<LevelGeneration>();
    }
    void Update()
    {
        if (SnakeTail.PlayerIsDead) { AudioOnDeath(); return; }
        if (LevelGeneration.inMainMenu) { CameraMovementBlock(true); return; }
        if (Input.GetMouseButton(0)) {
            Vector3 _delta = Input.mousePosition - _mouseStartPosition;
            Vector3 vector3 = new Vector3(_delta.x * sensitivity, 0, 0);

            transform.Translate(vector3);

            if (transform.position.x > 6.5f) { 
                transform.position = new Vector3(6.5f, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -6.5f) {
                transform.position = new Vector3(-6.5f, transform.position.y, transform.position.z);
            }

        }
        _mouseStartPosition = Input.mousePosition;
        CameraMovementBlock(false);
    }
    private void CameraMovementBlock(bool isBlocked)
    {
        int zOffset = 10;
        float x = transform.position.x;
        if (isBlocked) { zOffset = -10; x = 0; }
        transform.position = new Vector3(x, transform.position.y, Snake.transform.position.z - zOffset);
    }
    private void AudioOnDeath()
    {
        if (!allAudioPlayed) {
            volume -= Time.deltaTime / 2;
            GameAudio.volume = volume;
            if (volume <= 0) {
                DeathAudio.Play();
                allAudioPlayed = true;
            }
        }
    }
}
