using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public EnemyPattern[] patterns;
    public int delayEachWaves;

    void Start()
    {
        patterns = FindObjectsOfType<EnemyPattern>();
        Invoke("Spawn", delayEachWaves);
    }

    public void Spawn()
    {
        EnemyPattern pattern = patterns[0];
        StartCoroutine(IE_Spawn(pattern));
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
    }
}
