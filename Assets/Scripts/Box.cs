using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : ObjectHandler, WalkOver
{
    private const float FORCE_ON_BOX = 1;
    private bool isBroken;
    private float m_Timer = 4;

    public void ApplyEffect(GameObject player)
    {
        GetComponent<AudioSource>().Play();

        CollectPoints(player.GetComponent<Collider>());

        //Make children explode.....
        foreach (Transform child in transform)
        {
            //Give the force a range when it explodes.
            Vector3 force = new Vector3(Random.Range(-FORCE_ON_BOX, FORCE_ON_BOX), 0.0f, Random.Range(-FORCE_ON_BOX, FORCE_ON_BOX));

            child.gameObject.AddComponent<BoxCollider>();
            child.gameObject.AddComponent<Rigidbody>().AddForce(force);
        }

        ItemSpawner.m_BoxCounter -= 1;

        isBroken = true;

        DeleteObject(this.gameObject, isBroken, m_Timer);
        DeleteObject(this.gameObject.transform.parent.gameObject, isBroken, m_Timer);
    }

    void CollectPoints(Collider aCollider)
    {
        Player player = aCollider.GetComponent<Player>();

        Color color = player.playerColor;

        Tile tile = null;

        for (int i = 0; i < 8; ++i)
        {
            for (int j = 0; j < 8; ++j)
            {
                Vector3 tilePos = player.GetTileManager().GetGridTilePosition(i, j);

                tilePos.y = 0;//Reset cuz function below doesn't check actual tile y pos

                tile = player.GetTileManager().GetGridTile(tilePos);

                if (tile.color == color)
                {
                    player.GetTileManager().ChangeColors(Color.white, tile);
                    player.AddScore(1);
                }
            }
        }
        if (tile != null)
        {
            tile.powerUp = "";
        }
    }
}

