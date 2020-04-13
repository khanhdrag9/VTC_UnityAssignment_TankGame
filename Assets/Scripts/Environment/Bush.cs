using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bush : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    //private void OnTriggerEnter2D(Collider2D collision)
    {
        var o = collision.GetComponent<OpacityChanger>();

        if (o == null) return;
        if (GameManager.Instance.gamemode == GameMode.SINGLE)
        {
            o.SetAlpha(0.2f);
        }
        else
        {
            PhotonView view = o.GetComponent<PhotonView>();
            if(view.IsMine)
                o.SetAlpha(0.2f);
            else
                o.SetAlpha(0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var o = collision.GetComponent<OpacityChanger>();
        o?.SetAlpha(1);
    }
}
