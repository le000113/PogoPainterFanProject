using UnityEngine;
using System.Collections;

public class SpawnPoints : MonoBehaviour
{
    public GameObject[] spawnPoints;

    // Use this for initialization
    void Start()
    {
        LoadObjectsOnStart();
    }

    void LoadObjectsOnStart()
    {
        GameObject.Instantiate(spawnPoints[0], new Vector3(0, 0.9f, 0), Quaternion.identity);

        GameObject.Instantiate(spawnPoints[1], new Vector3(17.5f, 0.9f, 0), Quaternion.identity);

        GameObject.Instantiate(spawnPoints[2], new Vector3(0, 0.9f, 17.5f), Quaternion.identity);

        GameObject.Instantiate(spawnPoints[3], new Vector3(17.5f, 0.9f, 17.5f), Quaternion.identity);
    }
}
