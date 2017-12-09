using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoes : MonoBehaviour, WalkOver
{
    BasePlayer speed;

    public void ApplyEffect(GameObject obj)
    {
        speed.ApplySpeed();
    }
}
