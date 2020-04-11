using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootObject : MonoBehaviour
{
    public Bullet bulletPrefab;
    public float interval;
    public Transform shootPoint;

    private float nextShoot = 0;
    public bool canShoot => Time.time >= nextShoot;

    public void Shoot(Vector2 direction, float bulletSpeedScale = 1, float intervalSpeedScale = 1)
    {
        Shoot(Quaternion.Euler(0, 0, Helper.Angle90(direction)), bulletSpeedScale, intervalSpeedScale);
    }

    public void Shoot(Quaternion direction, float bulletSpeedScale = 1, float intervalSpeedScale = 1)
    {
        Bullet bullet = Instantiate(bulletPrefab);
        bullet.speed *= bulletSpeedScale;
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = direction;
        bullet.shooter = gameObject;

        nextShoot = Time.time + interval * intervalSpeedScale;
    }
}
