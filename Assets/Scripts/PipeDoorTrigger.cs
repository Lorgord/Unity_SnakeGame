using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDoorTrigger : MonoBehaviour
{
    public PipeManager pipeManager;
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out SnakeTail snakeTail))
        {
            if (snakeTail.PlayerIsDead) return;
            if (pipeManager.PipeHealth <= 0) {
                snakeTail.Freeze = false; return; }
            pipeManager.DoorHealthManager();
            snakeTail.Health--;
            snakeTail.HealthUpdate(false);
            snakeTail.Freeze = true;
        }
    }
}
