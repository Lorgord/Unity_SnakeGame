using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coinBody;
    public ParticleSystem ParticleSystem;
    private Vector3 RotationVelocity = new Vector3(0, 200, 0);
    private void Update()
    {
        Quaternion rotation = Quaternion.Euler(RotationVelocity * Time.deltaTime);
        transform.rotation = rotation * transform.rotation;
    }
    public void DestroyCoin()
    {
        ParticleSystem.Play();
        Destroy(coinBody);
    }
}
