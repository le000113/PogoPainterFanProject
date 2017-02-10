using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 direction;

    private const float MISSILE_SPEED = 5;

    private GameObject player;

    // Use this for initialization
    void Start()
    {
        direction = player.transform.forward;
        velocity = direction * MISSILE_SPEED;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * velocity;

        //TODO ADD STUN BOX.
    }
}
