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

    void Start()
    {
        //patterns = FindObjectsOfType<EnemyPattern>();
        currentPatternIndex = 0;
        Invoke("Spawn", delayEachWaves);
    }

    public void Spawn()
    {
        currentPattern = patterns[currentPatternIndex];
        currentPatternIndex++;
        StartCoroutine(IE_Spawn(currentPattern));
    }

    private IEnumerator IE_Spawn(EnemyPattern pattern)
    {
        var enemyTarget = FindObjectOfType<Player>(); 
        int number = pattern.objectAvailable.GetRandomAsInt();
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
        if(currentPattern.isDone)
        {
            Invoke("Spawn", delayEachWaves);
        }
    }
}
