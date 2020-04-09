using System;
using UnityEngine;

[Serializable]
public class Range
{
    [SerializeField]public float min;
    
    [SerializeField]public float max; 

    public Range()
    {
        min = 0;
        max = 0;
    }
    public Range(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
    public int GetRandomAsInt()
    {
        return UnityEngine.Random.Range(Convert.ToInt32(min), Convert.ToInt32(max));
    }
    public float GetRandomAsFloat()
    {
        return UnityEngine.Random.Range(min, max);
    }
}
