using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject spawnEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

   IEnumerator EnemySpawn()
    {
        while (enemyCount<10)
        {
            xPos = Random.Range(-18, -9);
            zPos = Random.Range(-11,-2);
            Instantiate(spawnEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            enemyCount += 1;
        }
    }
}
