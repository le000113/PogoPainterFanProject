using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : BasePlayer
{
    public Color playerColor;
    public Vector3 pDirection;

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

        RotateBot();
    }

    //Rotation for the AI. Basically all the AI code goes here cuz this is the only thing that affects their movement.
    protected void RotateBot()
    {
        //Check to see if the player has not rotated the object yet.
        if (m_canRotate == true)
        {
            int randomNumber = Random.Range(1, 5);

            randomNumber = DetermineTileToMoveTo(randomNumber);

            transform.Rotate(0, randomNumber * -90, 0);

            //Set the direction to whatever it's faced.
            Direction = transform.forward;

            Vector3 playerpos = transform.position;

            //Using tile's y position or else player is never considered on tile.
            playerpos.y = 0;

            Debug.Log(randomNumber);

            m_ForwardTile = m_TileManager.GetNextTile(Direction, m_CurrentTile);

            //We have rotated so now stop rotating until you move
            m_canRotate = false;
        }
    }

    int DetermineTileToMoveTo(int aRandomNumber)
    {
        int num = aRandomNumber;

        //Tile tile = DetermineTileToMoveTo(randomNumber);
        Vector3 checkDir = Quaternion.Euler(0, num * 90, 0) * transform.eulerAngles;

        Tile checkTile = m_TileManager.GetNextTile(checkDir, m_CurrentTile);
        if (checkTile != null)
        {

            return num;
        }

        while (num == aRandomNumber)
        {
            num = Random.Range(1, 5);
        }

        checkDir = Quaternion.Euler(0, num * 90, 0) * transform.eulerAngles;
        checkTile = m_TileManager.GetNextTile(checkDir, m_CurrentTile);
        if (checkTile != null)
        {
            return num;
        }

        int numTwo = aRandomNumber;
        while (numTwo == aRandomNumber || numTwo == num)
        {
            numTwo = Random.Range(1, 5);
        }

        return numTwo;
    }
}
