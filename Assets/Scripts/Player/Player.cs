using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : Tank
{
    public TextMesh nameDisplayPrefab;
    public Vector3 offsetName;

    private ControlAbleObject controlAbleObject;
    private PhotonView photonView;
    private OpacityChanger opacityChanger;

    public Transform nameDisplayer;


    public override void ReUpdateComponents()
    {
        base.ReUpdateComponents();
        controlAbleObject = GetComponent<ControlAbleObject>();
        opacityChanger = GetComponent<OpacityChanger>();

        if(GameManager.Instance.gamemode != GameMode.SINGLE)
            photonView = GetComponent<PhotonView>();
    }

    protected override void UpdateMine()
    {
        if (photonView && photonView.IsMine == false) return;

        barrelRotation?.Handle(controlAbleObject.mouseDirect, 1);
        if (shootObject.canShoot && (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)))
        {
            if (GameManager.Instance.gamemode != GameMode.SINGLE)
                photonView.RPC("Shoot", RpcTarget.All);
            else
                Shoot();
        }
    }

    [PunRPC]
    public void Shoot()
    {
        //shootObject?.Shoot(controlAbleObject.mouseDirect);
        shootObject?.Shoot(barrelRotation.transform.rotation);
    }

    //[PunRPC]
    public void SetName(string nameDisplay)
    {
        TextMesh o = GameManager.Instance.gamemode == GameMode.SINGLE ?
            Instantiate(nameDisplayPrefab, transform.position + offsetName, Quaternion.identity) :
            PhotonNetwork.Instantiate("Player/PlayerName", transform.position + offsetName, Quaternion.identity).GetComponent<TextMesh>();

        nameDisplayer = o.transform;
        o.text = nameDisplay;
        o.GetComponent<TextSync>().value = nameDisplay;

        opacityChanger.textMeshes.Add(o);
    }

    protected override void FixedUpdateMine()
    {
        if (photonView && photonView.IsMine == false) return;

        movement?.Handle(controlAbleObject.direct, 1);

        if (nameDisplayer)
            nameDisplayer.position = transform.position + offsetName;
    }

    public override void DestroyHandle()
    {
        Controller controller = FindObjectOfType<Controller>();
        if (controller == null || controller.gameObject == null) return;

        if (GameManager.Instance.gamemode == GameMode.SINGLE)
        {
            controller.ActiveDefeat();
        }
        else
        {
            if(controller.target.gameObject && controller.target.gameObject == gameObject)
                controller.ActiveDefeat();
            else
            {

            }
        }
    }
}
