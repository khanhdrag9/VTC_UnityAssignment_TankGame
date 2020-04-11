using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : Tank
{
    private ControlAbleObject controlAbleObject;
    private PhotonView photonView;

    public override void ReUpdateComponents()
    {
        base.ReUpdateComponents();
        controlAbleObject = GetComponent<ControlAbleObject>();

        if(GameManager.Instance.gamemode == GameMode.MULTI)
            photonView = GetComponent<PhotonView>();
    }

    protected override void UpdateMine()
    {
        barrelRotation?.Handle(controlAbleObject.mouseDirect, 1);

        if (photonView && photonView.IsMine == false) return;

        if (shootObject.canShoot && (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)))
        {
            Shoot();
        }
    }

    [PunRPC]
    public void Shoot()
    {
        shootObject?.Shoot(controlAbleObject.mouseDirect);
    }

    protected override void FixedUpdateMine()
    {
        movement?.Handle(controlAbleObject.direct, 1);
    }

    private void OnDestroy()
    {
        if (GameManager.Instance.gamemode == GameMode.MULTI)
        {
           
        }
        else
        {
            FindObjectOfType<Controller>()?.ActiveDefeat();
        }
    }
}
