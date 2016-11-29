using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    //TODO Add power ups in this class.
    protected float m_Speed;

    private float m_Timer = 0;

    protected virtual void SpawnObjectAtRandom()
    {
        //TODO Make a random generator to make the objects spawn at a random grid at a certain amount of time.
    }
    
    protected virtual void Upate()
    {

    }
}
