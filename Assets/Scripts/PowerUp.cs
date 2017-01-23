using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    //TODO Add power ups in this class.
    protected float m_Speed;
    protected float m_StunTime;

    private float m_Timer = 0;

    protected virtual void SpawnObjectAtRandom(GameObject powerUp)
    {
        //TODO Make a random generator to make the objects spawn at a random grid at a certain amount of time.
    }
    
    protected virtual void Upate()
    {

    }
}
