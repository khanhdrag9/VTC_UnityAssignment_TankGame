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
    private Transform nameDisplayer;


    public override void ReUpdateComponents()
    {
        base.ReUpdateComponents();
        controlAbleObject = GetComponent<ControlAbleObject>();

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

    [PunRPC]
    public void SetName(string name)
    {
        TextMesh o = GameManager.Instance.gamemode == GameMode.SINGLE ?
            Instantiate(nameDisplayPrefab, transform.position + offsetName, Quaternion.identity) :
            PhotonNetwork.Instantiate("Player/PlayerName", transform.position + offsetName, Quaternion.identity).GetComponent<TextMesh>();

        nameDisplayer = o.transform;
        o.GetComponent<Renderer>().sortingLayerName = "Objects";
        o.text = name;
    }

    protected override void FixedUpdateMine()
    {
        movement?.Handle(controlAbleObject.direct, 1);

        if (nameDisplayer)
            nameDisplayer.position = transform.position + offsetName;
    }

    private void OnDestroy()
    {
        if (nameDisplayer)
            Destroy(nameDisplayer.gameObject);

        if (GameManager.Instance.gamemode != GameMode.SINGLE && !photonView.IsMine)
        {
            
        }
        else
        {
            FindObjectOfType<Controller>()?.ActiveDefeat();
        }
    }
}
