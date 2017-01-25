using UnityEngine;
using System.Collections;

public class Player : PlayerClass
{
    public Color playerColor = Color.red;
    public Vector3 pDirection;
    public uint m_PlayerNumber;

    protected override void Start()
    {
        base.Start();
        color = playerColor;
        m_Speed = 1;
        Direction = pDirection;
        m_PlayerClaimNumber = m_PlayerNumber;
        m_CurrentTile = m_TileManager.GetGridTile(new Vector3(transform.position.x, 0, transform.position.z));
    }

    protected override void Update()
    {
        base.Update();
        //Changes the tile colour;
        m_TileManager.ChangeColors(color, m_CurrentTile);

        RotatePlayer();
    }
}
