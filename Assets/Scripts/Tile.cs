using UnityEngine;
using System.Collections;

public class Tile
{
    public Tile()
    {

    }

    public Tile(Vector3 aPosition, Color aColor, bool aOcupied, GameObject aTile)
    {
        position = aPosition;
        color = aColor;
        m_isOccupied = aOcupied;
        tile = aTile;
    }

    public Vector3 position { private set; get; }
    public Color color { set; get; }
    public bool m_isOccupied { set; get; }
    public GameObject tile { private set; get; }
}

 