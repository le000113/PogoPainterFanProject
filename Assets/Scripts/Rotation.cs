using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public enum ItemCheck
    {
        Lighting = 1,
        SpeedShoes
    }
    public ItemCheck items;

    private float m_Speed = 20f;

    void FixedUpdate()
    {
        switch (items)
        {
            case ItemCheck.Lighting:
                transform.Rotate(new Vector3(Time.deltaTime * m_Speed *10, 0.0f, 0.0f));
                break;
            case ItemCheck.SpeedShoes:
                transform.Rotate(new Vector3(0.0f, Time.deltaTime * m_Speed * 10, 0.0f));
                transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.fixedTime * Mathf.PI) * Time.deltaTime, transform.position.z);
                break;
        }
    }
}
