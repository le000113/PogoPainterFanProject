using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerClass : MonoBehaviour
{
    private float m_Timer = 0f;
    private float m_TileSize;

    private bool m_isRotating;
    private bool m_isRunning;

    protected float m_Speed;
    protected float m_Angle = 90;

    public float m_Score { get; protected set; }

    private Vector3 startPosition;
    private Vector3 endPosition;

    protected Color color;
    protected Vector3 Direction;

    protected virtual void Start()
    {
        m_TileSize = GameObject.FindGameObjectWithTag("TileGenerator").GetComponent<TileGenerator>().m_tileSize;
    }

    protected virtual void Update()
    {
        Movement();
        m_Timer += Time.deltaTime;
        if (m_Timer >= 1f)
        {
            m_isRotating = false;
            m_Timer = 0;
        }
    }

    private void Movement()
    {
        if (!m_isRunning)
        {
            StartCoroutine(smoothMove_Cr());
        }
    }

    protected void RotatePlayer()
    {
        if(m_isRotating == false)
        {
            if (InputManager.sInstance.MoveHorizontal.magnitude > 0.707f)
            {
                transform.LookAt(transform.position + InputManager.sInstance.MoveHorizontal, Vector3.up);
                Direction = transform.forward;
                m_isRotating = true;
            }
            else if (InputManager.sInstance.MoveVertical.magnitude > 0.707f)
            {
                transform.LookAt(transform.position + InputManager.sInstance.MoveVertical, Vector3.up);
                Direction = transform.forward;
                m_isRotating = true;
            }
        }

    }

    private IEnumerator smoothMove_Cr()
    {
        startPosition = transform.position;
        endPosition = startPosition + Direction * m_TileSize / 2;

        float t = 0;

        m_isRunning = true;

        while (t < 1f)
        {
            t += Time.deltaTime;

            transform.position = Vector3.Lerp(startPosition, endPosition, t);

            yield return null;
        }

        transform.position = endPosition;

        yield return new WaitForSeconds(0.02f);

        m_isRunning = false;
    }
}
