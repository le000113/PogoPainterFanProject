using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : ObjectHandler, WalkOver
{
    //Use This for Temp.
    public static bool m_useItem;

    [SerializeField]
    private GameObject item;
    public GameObject usableItem { get; set; }

    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    public void ApplyEffect(GameObject player)
    {
        if (!BasePlayer.m_isClaimed)
        {
            usableItem = null;

            usableItem = (GameObject)Instantiate(item, item.transform);

            usableItem.transform.parent = player.transform;

            usableItem.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, player.transform.position.z);

            DestroyObject(this.gameObject, 0);

            BasePlayer.m_isClaimed = true;

            m_useItem = true;
        }

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(!m_isClaimed)
    //    {
    //        if (collision.gameObject.tag == "Electric")
    //        {
    //            usableItem = null;

    //            usableItem = Instantiate(item, item.transform);

    //            usableItem.transform.parent = player.transform;

    //            usableItem.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, player.transform.position.z);

    //            player.powerUp = "Electric";

    //            DestroyObject(collision.gameObject, 0);

    //            m_isClaimed = true;

    //            m_useItem = true;
    //        }
    //        else if (collision.gameObject.tag == "Missile")
    //        {
    //            usableItem = null;
    //            //TODO change this to show missile when picked up
    //            usableItem = Instantiate(item, item.transform);

    //            usableItem.transform.parent = player.transform;

    //            usableItem.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, player.transform.position.z);

    //            player.powerUp = "Missile";

    //            DestroyObject(collision.gameObject, 0);

    //            m_isClaimed = true;

    //            m_useItem = true;
    //        }
    //    }
    //}

}
