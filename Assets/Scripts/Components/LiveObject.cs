using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveObject : MonoBehaviour
{
    [SerializeField] int startHP;
    [SerializeField] Vector2 offsetHPbar;
    [SerializeField] HPBar prefab;

    private HPBar hpBar;
    private int hp;
    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;

            if(hpBar == null)
            {
                hpBar = Instantiate(prefab);
                hpBar.transform.position = (Vector2)transform.position + offsetHPbar;
            }

            hpBar.value = Mathf.Clamp(hp / (float)startHP, 0f, 1f);

            if (hp <= 0) Die();

        }
    }

    private void Start()
    {
        HP = startHP;
    }

    private void Update()
    {
        if(hpBar)
            hpBar.transform.position = (Vector2)transform.position + offsetHPbar;
    }

    public void Die()
    {
        Destroy(gameObject);
        Destroy(hpBar.gameObject);
    }
}
