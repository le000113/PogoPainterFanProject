using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawn : MonoBehaviour
{
    private float m_Timer;

    private int m_Counter;

    private bool m_isLimitReached = false;

    [SerializeField]
    GameObject boxObject;

    TileGenerator tile;

    private void Start()
    {
        tile = GetComponent<TileGenerator>();
    }

    private void Update()
    {
        m_Timer += Time.deltaTime;

        if (m_Timer >= 5)
        {            
            int x = Random.Range(0,8);
            int y = Random.Range(0,8);

            GameObject spawnBox = (GameObject)Instantiate(boxObject);

            spawnBox.transform.position = tile.GetGridTile(x,y);

            m_Counter += 1;

            m_Timer = 0;
        }
    }

    private void AddScore()
    {
        //TODO add the score here.
    }
}
