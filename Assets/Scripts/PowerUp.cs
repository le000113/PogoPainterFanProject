using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{   
    protected enum PowerUpType
    {
        Missle = 0,
        Electricity,
        Invincibility
    }
    protected PowerUpType powerUp;

    protected float m_Speed;
    protected float m_StunTime;

    private int m_Counter;
    private float m_Timer = 0;

    private int m_xPosition;
    private int m_yPosition;

    private bool m_isLimitReached;

    private TileManager tile;
    private GameObject powerUpObject;

    protected virtual void Start()
    {
        tile = GetComponent<TileManager>();
    }

    protected virtual void Update()
    {
        if(!m_isLimitReached)
        {
            m_Timer += Time.deltaTime;
            
            if(m_Timer >= 10)
            {
                powerUp = (PowerUpType)Random.Range(0, 3);
                m_Timer = 0.0f;
            } 

        }
    }

    protected virtual void SpawnPowerUp(GameObject obj, string aPowerUpType)
    {
        if(m_Counter <= 1)
        {
            m_xPosition = Random.Range(0, 8);
            m_yPosition = Random.Range(0, 8);

            GameObject spawnObject = (GameObject)Instantiate(obj);

            spawnObject.transform.position = tile.GetGridTilePosition(m_xPosition, m_yPosition);

            m_Counter += 1;
        }
    }
}
