using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float m_Speed = 20f;

    void Update()
    {
        transform.Rotate(new Vector3(10 * Time.deltaTime * m_Speed, 0.0f, 0.0f));
    }
}
