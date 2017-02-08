using UnityEngine;
using System.Collections;

public class SpawnPoints : MonoBehaviour
{
    public GameObject[] spawnPoints;

    GameObject players;

    // Use this for initialization
    void Start()
    {
        LoadObjectsOnStart();
    }

    void LoadObjectsOnStart()
    {
        //Spawn all the objects in the specified location.
        players = GameObject.Instantiate(spawnPoints[0], new Vector3(0, 0.7f, 0), Quaternion.identity);
        players.transform.localEulerAngles = new Vector3(0, 90, 0);

        players = GameObject.Instantiate(spawnPoints[1], new Vector3(17.5f, 0.7f, 0), Quaternion.identity);
        players.transform.localEulerAngles = new Vector3(0, -90, 0);

        players = GameObject.Instantiate(spawnPoints[2], new Vector3(0, 0.7f, 17.5f), Quaternion.identity);
        players.transform.localEulerAngles = new Vector3(0, 90, 0);

        players = GameObject.Instantiate(spawnPoints[3], new Vector3(17.5f, 0.7f, 17.5f), Quaternion.identity);
        players.transform.localEulerAngles = new Vector3(0, -90, 0);
    }
}
