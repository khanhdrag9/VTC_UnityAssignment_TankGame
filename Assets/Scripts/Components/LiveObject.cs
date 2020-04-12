using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LiveObject : MonoBehaviour, IPunObservable
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
            if (hp <= 0) Die();
        }
    }

    private PhotonView photonView;

    private void Start()
    {
        HP = startHP;
        photonView = GetComponent<PhotonView>();
        hpBar = Instantiate(prefab);
        hpBar.transform.position = (Vector2)transform.position + offsetHPbar;
    }

    private void Update()
    {
        if (hpBar)
        {
            hpBar.transform.position = (Vector2)transform.position + offsetHPbar;
            hpBar.value = Mathf.Clamp(HP / (float)startHP, 0f, 1f);
        }
    }

    public void Die()
    {
        if (GameManager.Instance.gamemode == GameMode.SINGLE)
        {
            Destroy(gameObject);  
        }
        else
        {
            PhotonNetwork.Destroy(gameObject);
        }
        Destroy(hpBar.gameObject);
    }

    //private float old;
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //if (old != 0f)
        //    Debug.Log("Serialize Time : " + (Time.time - old) + " ms");
        //old = Time.time;
        if (photonView == null) return;

        if (photonView.IsMine)
        {
            stream.SendNext(HP);
        }
        else
        {
            HP = (int)stream.ReceiveNext();
        }
    }
}
