using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float liveTime;
    public float speed;
    public int damage;

    private void OnEnable()
    {
        Invoke("Destroy", liveTime);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        LiveObject live = collision.GetComponent<LiveObject>();
        if(live)
        {
            live.HP -= damage;
        }
        Destroy();
    }
}
