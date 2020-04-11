using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float liveTime;
    public float speed;
    public int damage;
    public GameObject explosion;
    public GameObject shooter { get; set; }

    private void OnEnable()
    {
        Invoke("Explode", liveTime);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void Explode()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (shooter &&  collision.gameObject == shooter) return;

        LiveObject live = collision.GetComponent<LiveObject>();
        if(live)
        {
            live.HP -= damage;
        }
        Explode();
    }
}
