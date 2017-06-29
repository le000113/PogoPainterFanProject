using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : ObjectHandler
{
    public bool m_isClaimed;

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

    private void OnCollisionEnter(Collision collision)
    {
        if(!m_isClaimed)
        {
            if (collision.gameObject.tag == "Electric")
            {
                usableItem = null;

                usableItem = Instantiate(item, item.transform);

                usableItem.transform.parent = player.transform;

                usableItem.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, player.transform.position.z);

                DestroyObject(collision.gameObject, 0);

                m_isClaimed = true;

                m_useItem = true;
            }
        }
    }

}
