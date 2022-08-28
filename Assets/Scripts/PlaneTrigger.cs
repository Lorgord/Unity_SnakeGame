using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTrigger : MonoBehaviour
{
    private LevelGeneration LevelGeneration;
    private SnakeTail Snake;
    private void Start()
    {
        LevelGeneration = FindObjectOfType<LevelGeneration>();
        Snake = FindObjectOfType<SnakeTail>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == Snake.GetComponent<Collider>()) {
            LevelGeneration.GeneratePlatform();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == Snake.GetComponent<Collider>()) {
            LevelGeneration.DestroyPlatform();
        }
    }
}
