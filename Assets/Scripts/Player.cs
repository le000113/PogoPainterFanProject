using UnityEngine;
using System.Collections;

public class Player : BasePlayer
{
    public Color playerColor = Color.red;
    public Vector3 pDirection;
    public bool isBot;

    protected override void Start()
    {
        base.Start();
        color = playerColor;
        m_Speed = 1;
        Direction = pDirection;
        m_CurrentTile = m_TileManager.GetGridTile(new Vector3(transform.position.x, 0, transform.position.z));

        //CHANGE set up forward tile
        m_ForwardTile = m_TileManager.GetGridTile(new Vector3(transform.position.x, 0, transform.position.z) + (transform.forward * 2.5f));
    }

    protected override void Update()
    {
        base.Update();
        //Changes the tile colour;
        m_TileManager.ChangeColors(color, m_CurrentTile);

        RotatePlayer();
    }

    public TileManager GetTileManager()
    {
        return m_TileManager;
    }

    public void AddScore(int aScore)
    {
        m_Score += aScore;
    }
}
