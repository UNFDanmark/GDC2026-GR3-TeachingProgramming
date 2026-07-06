using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1));
    }
}
