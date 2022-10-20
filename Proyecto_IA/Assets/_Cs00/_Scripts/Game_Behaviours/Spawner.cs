using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject collectiblePrefab;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private float toSpawn;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < toSpawn; i++)
        {
            float randomX = Random.Range(-18f, 18f);
            float randomY = Random.Range(-8f, 8f);
            Vector3 randomPos = new Vector3(randomX, randomY, 60.55f);
            GameObject.Instantiate(collectiblePrefab, randomPos, Quaternion.identity);
        }

        GameObject.Instantiate(playerPrefab, new Vector3(0,0,30f), Quaternion.identity);
    }

}
