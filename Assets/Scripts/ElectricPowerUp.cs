using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPowerUp : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject particle;

    //Remove this update later.

    private void Update()
    {
        if (PickUp.m_useItem == true)
        {
            if (Input.GetButton("AButtonFire"))
            {
                GameObject Shoot = Instantiate(particle);

                Shoot.transform.position = Player.transform.position;

                Shoot.transform.rotation = Player.transform.rotation;
                   
                PickUp.m_useItem = false;
            }
        }
    }

}
