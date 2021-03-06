﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Camera))]
public class Controller : MonoBehaviour
{
    public ControlAbleObject target;
    public Tilemap tilemap;
    public GameObject victory;
    public GameObject defeat;

    private Camera cam;

    public static float clampX;
    public static float clampY;
    
    public static float clampXCam;
    public static float clampYCam;

    private void Awake()
    {
#if UNITY_EDITOR
        if (GameManager.Instance == null)
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
#endif
    }

    private void Start()
    {
        cam = Camera.main;

        Vector3 p = tilemap.size;

        float halfHeight = cam.orthographicSize;
        float halfWidth = (Screen.width / (float)Screen.height) * halfHeight;

        clampX = p.x / 2f;
        clampY = p.y / 2f;

        clampXCam = clampX - halfWidth;
        clampYCam = clampY - halfHeight;

    }

    void Update()
    {
        if (target == null) return;

        UpdateControlAbleObject();
        
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        UpdatePosition();
    }

    private void UpdateControlAbleObject()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        target.direct = new Vector2(horizontal, vertical);

        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        target.mouseDirect = mousePos - (Vector2)target.transform.position;
    }

    private void UpdatePosition()
    {
        Vector3 position = target.transform.position;
        position = ClampPosition(position, true, Vector2.zero);
        position.z = -10;

        //transform.position = Vector3.Lerp(transform.position, position, 0.2f);

        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, position, ref velocity, 0.075f);
    }

    public static Vector2 ClampPosition(Vector2 position, bool inBGView, Vector2 margin)
    {
        float cx = (inBGView ? clampXCam : clampX) - margin.x;
        float cy = (inBGView ? clampYCam : clampY) - margin.y;

        position.x = Mathf.Clamp(position.x, -cx, cx);
        position.y = Mathf.Clamp(position.y, -cy, cy);

        return position;
    }

    public void ActiveVictory()
    {
        if (victory == null || defeat == null) return;

        if (!defeat.activeSelf)
            victory.SetActive(true);
    }

    public void ActiveDefeat()
    {
        if (victory == null || defeat == null) return;

        if (!victory.activeSelf)
            defeat.SetActive(true);
    }
}
