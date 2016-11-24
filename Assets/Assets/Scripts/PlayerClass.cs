using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerClass : MonoBehaviour
{
    float m_TileSize;
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
        transform.LookAt(transform.position + InputManager.sInstance.MoveHorizontal, Vector3.up);
    }

    private IEnumerator smoothMove_Cr()
    {
        startPosition = transform.position;
        endPosition = startPosition + Direction * m_TileSize / 2;

        float t = 0;

        m_isRunning = true;

        yield return new WaitForSeconds(0.05f);

        while (t < 1f)
        {
            t += Time.deltaTime;

            transform.position = Vector3.Lerp(startPosition, endPosition, t);

            yield return null;
        }

        transform.position = endPosition;

        yield return new WaitForSeconds(0.01f);

        m_isRunning = false;
    }

}
