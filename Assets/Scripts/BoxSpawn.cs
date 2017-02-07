using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawn : MonoBehaviour
{

    private float m_Timer;

    public static int m_Counter;

    private bool m_isLimitReached;

    [SerializeField]
    GameObject boxObject;

    TileManager tile;

    private void Start()
    {
        tile = GetComponent<TileManager>();
    }

    private void Update()
    {
        m_Timer += Time.deltaTime;

        if (!m_isLimitReached)
        {
            if (m_Timer >= 2)
            {
                //Get the values between 0 and 8
                int x = Random.Range(0, 8);
                int y = Random.Range(0, 8);

                //Spawn the box.
                GameObject spawnBox = (GameObject)Instantiate(boxObject);

                //Setting it's position.
                spawnBox.transform.position = tile.GetGridTilePosition(x, y);

                //Adding a counter to how many boxes are in the game.
                m_Counter += 1;

                //Reset the timer.
                m_Timer = 0;
            }
        }

        //Makes sure it doesn't spawn more than 4 boxes at once.
        if (m_Counter >= 3)
        {
            m_isLimitReached = true;
        }

        Debug.Log(m_Counter);
    }
}
