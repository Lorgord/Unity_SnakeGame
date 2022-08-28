using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceDeadTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SnakeTail snake)) {
            snake.PlayerDead();
        }
    }
}