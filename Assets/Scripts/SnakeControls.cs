using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeControls : MonoBehaviour
{
    private LevelGeneration LevelGeneration;
    public CameraControl CameraControl;
    public float followSpeed = 8;
    public float SnakeMoveSpeed = 5;
    public SnakeTail SnakeTail;

    private int _x = 3;
    void Awake()
    {
        gameObject.GetComponent<Transform>();
        LevelGeneration = FindObjectOfType<LevelGeneration>();
    }

    void Update()
    {
        if (SnakeTail.Freeze) return;
        if (SnakeTail.PlayerIsDead) return;

        transform.position += Vector3.forward * SnakeMoveSpeed * Time.deltaTime;

        if (LevelGeneration.inMainMenu) SnakeIdle();
        else SnakeFollowsCamera();    
    }

    private void SnakeFollowsCamera()
    {
         Vector3 CameraPosition = new Vector3
            (CameraControl.transform.position.x, transform.position.y, transform.position.z);
         transform.position = Vector3.MoveTowards
            (transform.position, CameraPosition, followSpeed * Time.deltaTime);
    }

    private void SnakeIdle()
    {
        Vector3 Idle = new Vector3(_x, transform.position.y, transform.position.z);

        switch (_x) {
            case 3:
                transform.position = Vector3.MoveTowards(transform.position, Idle, followSpeed * Time.deltaTime);
                if (transform.position.x >= _x) _x = -_x;
                break;
            case -3:
                transform.position = Vector3.MoveTowards(transform.position, Idle, followSpeed * Time.deltaTime);
                if (transform.position.x <= _x) _x = -_x;
                break;
        }

    }
}
