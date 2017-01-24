using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    //TODO Add power ups in this class.
    protected float m_Speed;
    protected float m_StunTime;

    private int m_Counter;
    private float m_Timer = 0;

    private int m_xPosition;
    private int m_yPosition;

    [SerializeField]
    private GameObject missle;
    [SerializeField]
    private GameObject Arrow;
    [SerializeField]
    private GameObject Electricity;
    [SerializeField]
    private GameObject SpeedBoots;

    private TileManager tile;

    protected virtual void Start()
    {
        tile = GetComponent<TileManager>();
    }

    protected virtual void Upate()
    {
    }

    protected virtual void SpawnPowerUp()
    {

    }

    //protected void SpawnMissle()
    //{
    //    if (m_Counter <= 1)
    //    {
    //        m_xPosition = Random.Range(0, 8);
    //        m_xPosition = Random.Range(0, 8);

    //        GameObject spawnMissle = (GameObject)Instantiate(missle);

    //        spawnMissle.transform.position = tile.GetGridTilePosition(m_xPosition, m_xPosition);

    //        m_Counter += 1;
    //    }
    //}

    //protected void SpawnArrowDirection()
    //{
    //    if (m_Counter <= 3)
    //    {
    //        m_xPosition = Random.Range(0, 8);
    //        m_xPosition = Random.Range(0, 8);

    //        GameObject spawnArrow = (GameObject)Instantiate(Arrow);

    //        spawnArrow.transform.position = tile.GetGridTilePosition(m_xPosition, m_xPosition);

    //        m_Counter += 1;
    //    }
    //}

    //protected void SpawnElectricity()
    //{
    //    if (m_Counter <= 1)
    //    {
    //        m_xPosition = Random.Range(0, 8);
    //        m_xPosition = Random.Range(0, 8);

    //        GameObject spawnElectricity = (GameObject)Instantiate(Electricity);

    //        spawnElectricity.transform.position = tile.GetGridTilePosition(m_xPosition, m_xPosition);

    //        m_Counter += 1;
    //    }
    //}


}
