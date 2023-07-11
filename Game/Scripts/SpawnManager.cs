using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShipPrefab;
    [SerializeField]
    private GameObject[] powerUpsArray;
    private GameManager _gameManager;

    private bool isSpawningEnemies = false;
    private bool isSpawningPowerUps = false;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpsSpawnRoutine());
    }

    public void StartSpawnRoutines()
    {
        if (!isSpawningEnemies)
        {
            StartCoroutine(EnemySpawnRoutine());
            isSpawningEnemies = true;
        }

        if (!isSpawningPowerUps)
        {
            StartCoroutine(PowerUpsSpawnRoutine());
            isSpawningPowerUps = true;
        }
    }

    IEnumerator EnemySpawnRoutine()
    {
        while (!_gameManager.gameOver)
        {
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }

        isSpawningEnemies = false;
    }

    IEnumerator PowerUpsSpawnRoutine()
    {
        while (!_gameManager.gameOver)
        {
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerUpsArray[randomPowerUp], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }

        isSpawningPowerUps = false;
    }
}
