using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private const float BOX_SPAWN_TIMER = 5f;
    private const float ITEM_SPAWN_TIMER = 5f;

    private float m_BoxTimer;
    private float m_ItemTimer;

    public static int m_BoxCounter;
    public static int m_ItemCounter;

    private bool m_BoxLimitReached;
    private bool m_ItemLimitReached;

    [SerializeField]
    GameObject[] powerUpObject;

    [SerializeField]
    GameObject boxObject;

    TileManager tile;

    private void Start()
    {
        tile = GetComponent<TileManager>();

       StartCoroutine(boxSpawner_cr());
       StartCoroutine(ItemSpawner_cr());
    }

    private IEnumerator ItemSpawner_cr()
    {
        while(true)
        {
            if (!m_ItemLimitReached)
            {
                yield return new WaitForSeconds(ITEM_SPAWN_TIMER);

                //Get the values between 0 and 8
                int x = Random.Range(0, 8);
                int y = Random.Range(0, 8);

                //Spawn the box.
                GameObject powerUp = (GameObject)Instantiate(powerUpObject[Random.Range(0, powerUpObject.Length)]);

                //Setting it's position.
                powerUp.transform.position = tile.GetGridTilePosition(x, y);

                //Adding a counter to how many boxes are in the game.
                m_ItemCounter += 1;

                //Reset the timer.
                m_ItemTimer = 0;

            }

            //Makes sure it doesn't spawn more than 4 boxes at once.
            if (m_ItemCounter >= 2)
            {
                m_ItemLimitReached = true;
            }
            else
            {
                if (m_ItemLimitReached == true)
                {
                    m_ItemLimitReached = false;
                }
            }
            yield return null;
        }

    }

    private IEnumerator boxSpawner_cr()
    {
        while(true)
        {
            if (!m_BoxLimitReached)
            {
                yield return new WaitForSeconds(BOX_SPAWN_TIMER);
                //Get the values between 0 and 8
                int x = Random.Range(0, 8);
                int y = Random.Range(0, 8);

                //Spawn the box.
                GameObject Box = (GameObject)Instantiate(boxObject);

                //Setting it's position.
                Box.transform.position = tile.GetGridTilePosition(x, y);

                //Adding a counter to how many boxes are in the game.
                m_BoxCounter += 1;

                //Reset the timer.
                m_BoxTimer = 0;
            }

            //Makes sure it doesn't spawn more than 4 boxes at once.
            if (m_BoxCounter >= 3)
            {
                m_BoxLimitReached = true;
            }
            else
            {
                if (m_BoxLimitReached == true)
                {
                    m_BoxLimitReached = false;
                }
            }
            yield return null;
        }
    }
        
}
