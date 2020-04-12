using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextNotification : MonoBehaviour
{
    public float timeRemain;
    public string text
    {
        get
        {
            return GetComponent<TextMesh>().text;
        }
        set
        {
            GetComponent<TextMesh>().text = value;
        }
    }
    void Start()
    {
        GetComponent<Renderer>().sortingLayerName = "Objects";
        Invoke("Finish", timeRemain);
    }

    public void Finish()
    {
        Destroy(gameObject);
    }

    public void Update()
    {
        Vector3 newpos = transform.localPosition + Vector3.up * 2f * Time.deltaTime;
        newpos.z = 10;
        transform.localPosition = newpos;
    }
}
