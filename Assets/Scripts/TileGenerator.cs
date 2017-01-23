using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject TileFloor;

    [SerializeField]
    GameObject ScoreBox;

    Tile[,] Grid;

    Vector3[,] Gridposition;
    Vector3 initialPosition;

    int positionTileX = 8;
    int positionTileY = 8;
    float m_offset = 2.5f;

    int GridSize;

    public float m_tileSize { get; private set; }

    // Use this for initialization
    private void Start()
    {
        initialPosition = new Vector3(0, 0, 0);

        GenerateGrid();

        m_tileSize = GameObject.FindGameObjectWithTag("Tile").GetComponentInChildren<MeshRenderer>().bounds.size.x * 2;

        GridSize = positionTileX * positionTileY;
    }

    public void ChangeColors(Color aColor, Vector3 aPlayerTile)
    {
        for (int i = 0; i < positionTileX; ++i)
        {
            for (int j = 0; j < positionTileY; ++j)
            {
                if (aPlayerTile == Grid[i, j].position)
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

                //Set the grid and then generate it.
                Grid[i, j] = new Tile(gridPlane.transform.position, Color.white, false, gridPlane);
            }
        }
    }

    private void SpawnRandomBox()
    {
        for (int i = 0; i < GridSize; ++i)
        {
            GameObject spawnBox = (GameObject)Instantiate(ScoreBox);

            spawnBox.transform.position = new Vector3(Random.Range(i, GridSize), initialPosition.y, Random.Range(i, GridSize));
        }
    }

    public Vector3 GetGridTile(Vector3 aPosition)
    {
        //Go through the rows from the x and y position.
        for (int i = 0; i < positionTileX; ++i)
        {
            for (int j = 0; j < positionTileY; ++j)
            {
                if (aPosition == Grid[i,j].position)
                {
                    return Grid[i, j].position;
                }
            }
        }
        return Vector3.zero;
    }
}
