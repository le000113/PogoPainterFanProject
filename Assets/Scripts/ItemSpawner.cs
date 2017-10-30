using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private const float BOX_SPAWN_TIMER = 5f;
    private const float ITEM_SPAWN_TIMER = 10f;

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
        while (true)
        {
            if (!m_ItemLimitReached)
            {
                yield return new WaitForSeconds(ITEM_SPAWN_TIMER);

                bool canSpawn = false;

                int itemSpawn = Random.Range(1, 4);

                //Checking if able to spawn, if successful then item will spawn and exit while loop
                while (canSpawn == false)
                {
                    canSpawn = SpawnChecker(null, itemSpawn);

                }

                //Adding a counter to how many boxes are in the game.
                m_ItemCounter += 1;

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
        while (true)
        {
            if (!m_BoxLimitReached)
            {
                yield return new WaitForSeconds(BOX_SPAWN_TIMER);

                bool canSpawn = false;
                string box = "Box";

                //Checking if able to spawn, if successful then item will spawn and exit while loop
                while (canSpawn == false)
                {
                    canSpawn = SpawnChecker(box, 0);
                }

                //Adding a counter to how many boxes are in the game.
                m_BoxCounter += 1;

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

    bool SpawnChecker(string aPowerup, int index)
    {
        //Get the values between 0 and 8
        int x = Random.Range(0, 8);
        int y = Random.Range(0, 8);

        Vector3 tilePos = tile.GetGridTilePosition(x, y);

        tilePos.y = 0;//Reset cuz function below doesn't check actual tile y pos

        if (tile.GetGridTile(tilePos).powerUp != "")
        {
            return false;
        }

        tile.GetGridTile(tilePos).powerUp = aPowerup;

        //Setting it's position.
        tilePos.y = 0.2f; //Gotta fix the y cuz we are gonna spawn it now
        //Spawn the box.
        if (aPowerup == "Box")
        {
            GameObject Box = (GameObject)Instantiate(boxObject);
            Box.transform.position = tile.GetGridTilePosition(x, y);
        }

        switch (index)
        {
            case 1:
                GameObject powerUp = (GameObject)Instantiate(powerUpObject[Random.Range(0, powerUpObject.Length)]);
                powerUp.transform.position = tile.GetGridTilePosition(x, y);
                break;
            case 2:
                GameObject powerUp2 = (GameObject)Instantiate(powerUpObject[Random.Range(0, powerUpObject.Length)]);
                powerUp2.transform.position = tile.GetGridTilePosition(x, y);
                break;
            case 3:
                GameObject powerUp3 = (GameObject)Instantiate(powerUpObject[Random.Range(0, powerUpObject.Length)]);
                powerUp3.transform.position = tile.GetGridTilePosition(x, y);
                break;
        }

        return true;
    }
}
