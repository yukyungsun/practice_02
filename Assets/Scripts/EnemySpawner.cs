using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; // 적 프리팹
    [SerializeField]
    private float spawnTime; // 적 생성 주기
    [SerializeField]
    private Transform[] wayPoints; // 현재 스테이지 이동경로


    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

    // Update is called once per frame
    private IEnumerator SpawnEnemy()
    {
        while ( true )
        {
            GameObject clone = Instantiate(enemyPrefab); // 적 오브젝트 생성
            Enemy enemy = clone.GetComponent<Enemy>();

            enemy.Setup(wayPoints);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
