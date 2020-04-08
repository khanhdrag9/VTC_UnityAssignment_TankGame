using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootObject : MonoBehaviour
{
    public Bullet bulletPrefab;
    public float interval;
    public Transform shootPoint;

    private float nextShoot = 0;

    public void Shoot(Vector2 direction, float bulletSpeedScale, float intervalSpeedScale)
    {
        if (Time.time < nextShoot) return;

        Bullet bullet = Instantiate(bulletPrefab);
        bullet.speed *= bulletSpeedScale;
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = transform.rotation;

        nextShoot = Time.time + interval * intervalSpeedScale;
    }
}
