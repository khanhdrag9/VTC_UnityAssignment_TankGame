using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private int currentWave;
    private int currentKilledInWave;
    private int[] totalWaves;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void Setup(int[] totalWaves)
    {
        slider.value = 0;
        this.totalWaves = totalWaves;
    }

    public void Increase()
    {
        if(currentWave >= totalWaves.Length)
        {
            slider.value = 1;
            return;
        }

        currentKilledInWave++;
        if(currentKilledInWave > totalWaves[currentWave])
        {
            currentKilledInWave = 0;
            if(++currentWave >= totalWaves.Length)
            {
                slider.value = 1;
                return;
            }
        }

        float wavePart = (1f / totalWaves.Length);
        float inWavePart = wavePart / totalWaves[currentWave];
        slider.value = wavePart * currentWave + inWavePart * currentKilledInWave;
    }

    void Update()
    {
        
    }
}
