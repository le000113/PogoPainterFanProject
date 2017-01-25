using UnityEngine;
using System.Collections;

public class Tile
{
    public Tile()
    {

    }

    public Tile(Vector3 aPosition, Color aColor, uint aOcupied, GameObject aTile, Vector2 aCoords)
    {
        position = aPosition;
        color = aColor;
        m_OccupiedByPlayer = aOcupied;
        tile = aTile;
        coordinates = aCoords;
    }

    public Vector3 position { private set; get; }
    public Color color { set; get; }
    public uint m_OccupiedByPlayer { set; get; }
    public bool m_IsOccupied;
    public GameObject tile { private set; get; }
    public Vector2 coordinates { private set; get; }
}

 