using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPattern : MonoBehaviour
{
    public List<Vector2> points;
    public int startLoop;
    public float delayAvailable;
    public int objectAvailable;

    public bool isDone => enemies != null && countKilled >= objectAvailable;
    public ProgressBar progress { get; set; }
    public List<EnemyHandle> enemies { get; set; }
    public int countKilled { get; set; }

    public void AddEnemy(Enemy enemy, int startIndex)
    {
        if (enemies == null)
        {
            enemies = new List<EnemyHandle>();
        }

        var exist = enemies.Find(e => e.enemy != null && e.enemy.gameObject == enemy.gameObject);
        if (exist != null)
            exist.indexMovement = startIndex;
        else
        {
            enemies.Add(new EnemyHandle
            {
                enemy = enemy,
                indexMovement = startIndex
            });

            enemy.transform.position = points[startIndex];
        }
    }

    private void FixedUpdate()
    {
        if (enemies == null) return;

        for(int i = 0; i < enemies.Count;)
        {
            EnemyHandle e = enemies[i];

            if (e.enemy == null)
            {
                enemies.RemoveAt(i);
                progress?.Increase();
                countKilled++;
                continue;
            }

            ++i;

            if (e.enemy.MoveTo(points[e.indexMovement]) == false) continue;
            
            if (++e.indexMovement == points.Count)
                e.indexMovement = startLoop;
        }
    }

    public class EnemyHandle
    {
        public Enemy enemy;
        public int indexMovement;
    }
}
