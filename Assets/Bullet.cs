using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletLifeTime;

    float timeLeft;

    void Start()
    {
        timeLeft = BulletLifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = timeLeft - Time.deltaTime;
        if (timeLeft <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            Destroy(collision.gameObject);
    }
}
