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

    public void Shoot(Vector2 direction, float bulletSpeedScale, float intervalSpeedScale)
    {
        Shoot(Quaternion.Euler(0, 0, Helper.Angle90(direction)), bulletSpeedScale, intervalSpeedScale);
    }

    public void Shoot(Quaternion direction, float bulletSpeedScale, float intervalSpeedScale)
    {
        Bullet bullet = Instantiate(bulletPrefab);
        bullet.speed *= bulletSpeedScale;
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = direction;

        nextShoot = Time.time + interval * intervalSpeedScale;
    }
}
