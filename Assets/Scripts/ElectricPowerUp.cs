using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPowerUp : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject Lightning;

    ItemSpawner spawn;

    private bool m_isItemClaimed;
    private bool m_hasBeenCollided;

    private void OnCollisionEnter(Collision aCollision)
    {
        if(!m_isItemClaimed)
        {
            if (aCollision.gameObject.tag == "Player")
            {
                spawn.AttachObjects(Lightning, player);
                Debug.Log("I got hit");

            }

            m_hasBeenCollided = true;
        }
    }
}
