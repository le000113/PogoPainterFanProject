using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    public void DeleteObject(GameObject obj, bool isActive, float timer)
    {
        if (isActive == true)
        {
            Destroy(obj, timer);
        }
    }


    public bool TileCollision(GameObject powerUp)
    {
        Tile[,] CheckLength;
        for(int i = 0; i < 8; ++i)
        {
            for(int j = 0; j < 8; ++j)
            {

            }
        }

        return true;
    }
}
