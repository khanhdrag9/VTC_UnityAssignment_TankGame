using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public EnemyPattern[] patterns;
    public int delayEachWaves;

    private EnemyPattern currentPattern;
    private int currentPatternIndex;
    private ProgressBar progress;

    void Start()
    {
        //patterns = FindObjectsOfType<EnemyPattern>();
        progress = FindObjectOfType<ProgressBar>();

        int[] totalWaves = new int[patterns.Length];
        for(int i = 0; i < patterns.Length; i++)
        {
            totalWaves[i] = patterns[i].objectAvailable;
            patterns[i].progress = progress;
        }

        progress.Setup(totalWaves);

        currentPatternIndex = 0;
        Invoke("Spawn", delayEachWaves);
    }

    public void Spawn()
    {
        currentPattern = patterns[currentPatternIndex];
        if(++currentPatternIndex >= patterns.Length)
        {
            Debug.Log("victory");
            return;
        }

        StartCoroutine(IE_Spawn(currentPattern));
    }

    private IEnumerator IE_Spawn(EnemyPattern pattern)
    {
        var enemyTarget = FindObjectOfType<Player>();
        int number = pattern.objectAvailable;
        for (int i = 0; i < number; i++)
        {
            Enemy e = Instantiate(enemyPrefab);
            e.target = enemyTarget.transform;
            pattern.AddEnemy(e, 0);
            yield return new WaitForSeconds(pattern.delayAvailable);
        }
    }
    void Update()
    {
        if(currentPattern != null && currentPattern.isDone)
        {
            Invoke("Spawn", delayEachWaves);
        }
    }
}
