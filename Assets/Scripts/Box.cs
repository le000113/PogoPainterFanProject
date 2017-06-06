using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : ObjectHandler
{
    private const float FORCE_ON_BOX = 1;
    private bool isBroken;
    private float m_Timer = 4;

    private void OnTriggerEnter(Collider collider)
    {
        GetComponent<BoxCollider>().enabled = false;

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
    }
}

