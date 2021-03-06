﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    GameObject TileFloor;

    Tile[,] Grid;

    Vector3[,] Gridposition;
    Vector3 initialPosition;

    int positionTileX = 8;
    int positionTileY = 8;
    float m_offset = 2.5f;

    public float m_tileSize { get; private set; }

    // Use this for initialization
    private void Start()
    {
        initialPosition = new Vector3(0, 0, 0);

        GenerateGrid();

        m_tileSize = GameObject.FindGameObjectWithTag("Tile").GetComponentInChildren<MeshRenderer>().bounds.size.x * 2;
    }

    public void ChangeColors(Color aColor, Tile aPlayerTile)
    {
        for (int i = 0; i < positionTileX; ++i)
        {
            for (int j = 0; j < positionTileY; ++j)
            {
                if (aPlayerTile == Grid[i, j])
                {
                    //Used for collecting points later
                    Grid[i, j].color = aColor;
                    //Actually changing the color
                    Grid[i, j].tile.GetComponent<Renderer>().material.color = aColor;

                }
            }
        }
    }

    private void GenerateGrid()  
    {
        //Create the grid.
        Grid = new Tile[positionTileX + 1, positionTileY + 1];

        //Go through the rows from the x and y position.
        for (int i = 0; i < positionTileX; ++i)
        {
            for (int j = 0; j < positionTileY; ++j)
            {
                //Create the tile.
                GameObject gridPlane = (GameObject)Instantiate(TileFloor);

                //Set the tiles positions.
                gridPlane.transform.position = new Vector3(initialPosition.x + i * m_offset, initialPosition.y, initialPosition.z + j * m_offset);

                Vector2 coords = new Vector2(i, j);

                //Set the grid and then generate it.
                Grid[i, j] = new Tile(gridPlane.transform.position, Color.white, false, gridPlane, coords);
                Grid[i, j].type = 0;
            }
        }
    }

    public Vector3 GetGridTilePosition(int xPosition, int yPosition)
    {
        Vector3 tilePosition = Grid[xPosition, yPosition].position;

        tilePosition.y = 0.2f;

        return tilePosition;
    }

    public Tile GetGridTile(Vector3 aPosition)
    {
        //Go through the rows from the x and y position.
        for (int i = 0; i < positionTileX; ++i)
        {
            for (int j = 0; j < positionTileY; ++j)
            {
                if (aPosition == Grid[i, j].position)
                {
                    return Grid[i, j];
                }
            }
        }
        return null;
    }

    public Tile GetGridTile(int x, int y)
    {
        return Grid[x, y];
    }

    //Gets the tile infront of the player depending on their direction
    public Tile GetNextTile(Vector3 aDirection, Tile aCurrentTile)
    {
        float currentXCoord = aCurrentTile.coordinates.x;
        float currentYCoord = aCurrentTile.coordinates.y;

        int x = (int)(currentXCoord + Mathf.Round(aDirection.x));
        int y = (int)(currentYCoord + Mathf.Round(aDirection.z));

        if (x >= 0 && y >= 0)
        {
            return Grid[x, y];
        }
        else
        {
            return null;
        }
    }
}
