using UnityEngine;
using System.Collections;

public class Player2 : PlayerClass
{
    protected override void Start()
    {
        base.Start();
        color = Color.blue;
        m_Speed = 1;
        Direction = -transform.right;
        m_CurrentTile = new Vector3(transform.position.x, 0, transform.position.z);
    }

    protected override void Update()
    {
        base.Update();
        //Change da colours brah
        m_TileGenerator.ChangeColors(color, m_CurrentTile);

        RotatePlayer();
    }
}
