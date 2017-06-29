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
            if (Input.GetButton("AButtonFire") || Input.GetKeyDown(KeyCode.Space))
            {
                GameObject Shoot = Instantiate(particle);

                Shoot.transform.position = Player.transform.position + Player.transform.forward;

                Shoot.transform.rotation = Player.transform.rotation;
                   
                PickUp.m_useItem = false;
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Stun");
            other.GetComponent<Player>().Stun();
        }
    }

}
