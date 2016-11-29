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
        //Obtain the size for the tile.
        m_TileSize = GameObject.FindGameObjectWithTag("TileGenerator").GetComponent<TileGenerator>().m_tileSize;
    }

    protected virtual void Update()
    {
        //Call the movement function.
        Movement();

        //Set a timer so that the player can't rotate too fast.
        m_Timer += Time.deltaTime;
        if (m_Timer >= 1f)
        {
            //if it's not rotating anymore, set it to false.
            m_isRotating = false;
            m_Timer = 0;
        }
    }

    private void Movement()
    {
        if (!m_isRunning)
        {
            //Start the Coroutine.
            StartCoroutine(smoothMove_Cr());
        }
    }

    protected void RotatePlayer()
    {
        //Check to see if the player has not rotated the object yet.
        if (m_isRotating == false)
        {
            //Check it's magnitutde to see if the input value is between 0 to 1.
            if (InputManager.sInstance.MoveHorizontal.magnitude > 0.707f)
            {
                //Look at where the position the analog stick is pointing towards.
                transform.LookAt(transform.position + InputManager.sInstance.MoveHorizontal, Vector3.up);

                //Set the direction to whatever it's faced.
                Direction = transform.forward;

                //If it's rotating this function will not be called again so soon.
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
        //set the starting point to whatever the players positioned at.
        startPosition = transform.position;

        //The end is where the next tile grid will be.
        endPosition = startPosition + Direction * m_TileSize / 2;

        float t = 0;

        //Make sure it doesn't go out of bounds.
        if (!(endPosition.x < -1f || endPosition.x > 18 || endPosition.z < -1 || endPosition.z > 18))
        {
            //Make sure the object is moving.
            m_isRunning = true;

            while (t < 1f)
            {
                t += Time.deltaTime;

                //Lerping it's position from the start to the end.
                transform.position = Vector3.Lerp(startPosition, endPosition, t);

                yield return null;
            }
            //Make the objects position to wherever the end will be.
            transform.position = endPosition;

            //Have a delay in between the movement so that animation can blend in.
            yield return new WaitForSeconds(0.02f);

            //Set it back to false and run through the coroutine again.
            m_isRunning = false;
        }

    }
}
