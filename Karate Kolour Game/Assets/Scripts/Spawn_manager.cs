using System.Collections;
using UnityEngine;

public class Spawn_manager : MonoBehaviour
{
    public player_char points;
    public GameObject Enemy_Prefab;
    public GameObject[] Spawners;
    public bool isSpawningEnemies;
    public int[] cantEnemies;
    public int enemycounter;
    public int waiTime = 5;
    public Transform[] spawners;

    public enum actualEnemiesState
    {
        easy, 
        normal, 
        hard
    }
    public actualEnemiesState state;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
        state = actualEnemiesState.easy;
    }

    public void WaitTime(actualEnemiesState state)
    {
        switch (state)
        {
            case actualEnemiesState.normal:
                waiTime = 3;
                break;
            case actualEnemiesState.hard:
                waiTime = 1;
                break;
            default:
                break;
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (isSpawningEnemies)
        {
            for (int i = 0; i < cantEnemies[(int)state]; i++)
            {
                Instantiate(Enemy_Prefab, spawners[Random.Range(0, spawners.Length)].position, Quaternion.identity);
                enemycounter++;
                if (points.score >= 5 && points.score <= 10) { state = actualEnemiesState.normal; }
                else if (points.score > 10) { state = actualEnemiesState.hard; }
                WaitTime(state);
                yield return new WaitForSeconds(waiTime);
            }
            
        }
    }
}
