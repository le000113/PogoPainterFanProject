using UnityEngine;
using System.Collections;

public class Player1 : PlayerClass
{
    //private int m_TileSize;
    //protected Color color;

    //protected float m_Speed;
    //protected float m_Angle = 90;

    //public float m_Score { get; protected set; }

    //protected Vector3 Direction;

    protected override void Start()
    {
        base.Start();
        color = Color.red;
        m_Speed = 1;
        Direction = transform.right;
    }

    protected override void Update()
    {
        base.Update();

        RotatePlayer();
    }
}
