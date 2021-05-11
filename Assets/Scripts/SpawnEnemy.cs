using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private bool isInfinite;

    [Header("Infinite")]
    [SerializeField]
    private int enemiesANight = 10;
    private float timeTillNight;
    private float timeTillMorning;
    private bool isMorning;
    private float timeTillSpawn;
    
    [Header("Round")]
    [SerializeField]
    private int[] enemiesPerRound = new int[10];
    [SerializeField]
    private int currentRound;
    [SerializeField]
    private int[] roundTimeInMinutes = new int[10];
    private float timeToSpawn;
    private float timeToNextRound;
    [SerializeField]
    private string sceneName;

    [Header("Prefabs")]
    [SerializeField]
    private GameObject enemyPrefab;

    private void Start()
    {
        timeToSpawn = 3600 / enemiesPerRound[currentRound];
        timeToNextRound = 60 * roundTimeInMinutes[currentRound];
        timeTillNight = 3600 * 5;
        timeTillMorning = 0;
        isMorning = true;
        timeTillSpawn = 3600 / enemiesANight;
    }

    private void FixedUpdate()
    {
        HandleRound();
        HandleSpawn();
    }

    private void HandleRound()
    {
        if (!isInfinite)
        {
            timeToNextRound -= Time.deltaTime;
            if (timeToNextRound <= 0)
            { 
                    timeToSpawn = 3600 / enemiesPerRound[currentRound];
                    timeToNextRound = 3600 * roundTimeInMinutes[currentRound];
                    currentRound++;
                if (currentRound >= roundTimeInMinutes.Length-1)
                {
                    SceneManager.LoadScene(sceneName);
                }
       
            }
        }
    }
    private void HandleSpawn()
    {
        if (!isInfinite)
        {
            timeToSpawn -= Time.deltaTime;
            if (timeToSpawn <= 0)
            {
                //Instantiate(enemyPrefab);
                Debug.Log("Enemy Spawned");
                timeToSpawn = 3600 / enemiesPerRound[currentRound];
            }
        } else
        {
            if (isMorning)
            {
                timeTillNight -= Time.deltaTime;
                if (timeTillNight <= 0)
                {
                    isMorning = false;
                    timeTillNight = 0;
                }
            } else
            {
                timeTillMorning -= Time.deltaTime;
                if (timeTillMorning <= 0)
                {
                    isMorning = true;
                    timeTillNight = 3600 * 5;
                } else
                {
                    timeTillSpawn -= Time.deltaTime;
                    if (timeTillSpawn <= 0)
                    {
                        //Instantiate(enemyPrefab);
                        Debug.Log("Enemy Spawned");
                        timeTillSpawn = 3600 / enemiesANight;
                    }

                }
            }
        }
    }
}
