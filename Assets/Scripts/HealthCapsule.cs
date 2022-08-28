using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCapsule : MonoBehaviour
{
    private Vector3 RotationVelocity = new Vector3(0, 200, 0);
    void Update()
    {
        Quaternion rotation = Quaternion.Euler(RotationVelocity * Time.deltaTime);
        transform.rotation = rotation * transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SnakeTail snake)) {
            snake.Health++;
            snake.HealthUpdate(true);
            Destroy(gameObject);
        }
    }
}
