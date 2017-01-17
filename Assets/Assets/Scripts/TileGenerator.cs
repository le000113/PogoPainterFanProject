using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject TileFloor;

    [SerializeField]
    GameObject ScoreBox;

    GameObject[,] Grid;

    Vector3[,] Gridposition;
    Vector3 initialPosition;

    List<Color> gridColors;

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

        gridColors = new List<Color>();

        GridSize = positionTileX * positionTileY;

        InitializeColors();

        //gridColors[0] = Color.red;

        for (int i = 0; i < gridColors.Count; ++i)
        {
            if (gridColors[i] == Color.red)
            {
                //Grid[0, 0].GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    public void ChangeColors(Color aColor, Vector3 aPlayerTile)
    {
        //TODO know what tile they are in.
        for (int i = 0; i < positionTileX; ++i)
        {
            for (int j = 0; j < positionTileY; ++j)
            {
                if (aPlayerTile == Gridposition[i, j])
                {
                    //gridColors[i]=aColor;
                    Grid[i, j].GetComponent<Renderer>().material.color = aColor;
                }
            }
        }
    }

    private void InitializeColors()
    {
        //Go through all the tiles and set their colour to white.
        for (int i = 0; i < GridSize; ++i)
        {
            gridColors.Add(Color.white);
        }
    }

    private void GenerateGrid()
    {
        //Create the grid.
        Grid = new GameObject[positionTileX + 1, positionTileY + 1];
        Gridposition = new Vector3[positionTileX + 1, positionTileY + 1];

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
                Grid[i, j] = gridPlane;
                Gridposition[i, j] = gridPlane.transform.position;
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
                if (aPosition == Gridposition[i, j])
                {
                    return Gridposition[i, j];
                }
            }
        }
        return Vector3.zero;
    }
}
