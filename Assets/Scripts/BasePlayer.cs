﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BasePlayer : MonoBehaviour
{
    public static bool m_isClaimed;

    private float m_Timer = 0f;
    private float m_Tile;

    protected bool m_canRotate;
    protected bool m_isRunning;

    protected bool m_isStunned;

    protected float m_Speed;
    protected float m_Angle = 90;

    protected string pHorizontal;
    protected string pVertical;
    protected string pBButtonFire;

    public int numPlayers;

    public float m_Score { get; protected set; }

    private Vector3 startPosition;
    private Vector3 endPosition;

    protected Color color;
    protected Vector3 Direction;

    protected TileManager m_TileManager;
    protected Tile m_CurrentTile;

    //CHANGE here get a tile for forward
    protected Tile m_ForwardTile;

    protected void Awake()
    {
        m_TileManager = GameObject.FindGameObjectWithTag("TileGenerator").GetComponent<TileManager>();
    }

    protected virtual void Start()
    {
        //Obtain the size for the tile.
        m_Tile = m_TileManager.m_tileSize;

        //Go through the numbers. And check what player it is.
        pHorizontal = "P" + numPlayers + "Horizontal";
        pVertical = "P" + numPlayers + "Vertical";
        pBButtonFire = "P" + numPlayers + "BButtonFire";

        m_isClaimed = false;
    }

    protected virtual void Update()
    {
        //Movement
        if (!m_isRunning && !m_isStunned)
        {
            //Start the Coroutine.
            if (InputManager.sInstance.InputControllerHorizontal(pHorizontal).magnitude > 0.5f)
                StartCoroutine(smoothMove_Cr());
            else if (InputManager.sInstance.InputControllerVertical(pVertical).magnitude > 0.5f)
                StartCoroutine(smoothMove_Cr());
        }
    }

    protected void RotatePlayer()
    {
        //Check to see if the player has not rotated the object yet.
        if (m_canRotate == true)
        {
            //Check it's magnitutde to see if the input value is between 0 to 1.
            if (InputManager.sInstance.InputControllerHorizontal(pHorizontal).magnitude > 0.707f)
            {
                //Look at where the position the analog stick is pointing towards.
                transform.LookAt(transform.position + InputManager.sInstance.InputControllerHorizontal(pHorizontal), Vector3.up);

                //Set the direction to whatever it's faced.
                Direction = transform.forward;
            }
            else if (InputManager.sInstance.InputControllerVertical(pVertical).magnitude > 0.707f)
            {
                transform.LookAt(transform.position + InputManager.sInstance.InputControllerVertical(pVertical), Vector3.up);
                Direction = transform.forward;
            }
            Vector3 playerpos = transform.position;

            //Using tile's y position or else player is never considered on tile.
            playerpos.y = 0;

            m_ForwardTile = m_TileManager.GetNextTile(Direction, m_CurrentTile);
        }
    }

    protected void KeyboardControls()
    {
        if (m_canRotate == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.LookAt(transform.position - Vector3.right, Vector3.up);
                Direction = transform.forward;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.LookAt(transform.position + Vector3.right, Vector3.up);
                Direction = transform.forward;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.LookAt(transform.position - Vector3.forward, Vector3.up);
                Direction = transform.forward;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                transform.LookAt(transform.position + Vector3.forward, Vector3.up);
                Direction = transform.forward;
            }
            Vector3 playerpos = transform.position;

            //Using tile's y position or else player is never considered on tile.
            playerpos.y = 0;

            m_ForwardTile = m_TileManager.GetNextTile(Direction, m_CurrentTile);
        }
    }

    private IEnumerator smoothMove_Cr()
    {
        //set the starting point to whatever the players positioned at.
        startPosition = transform.position;

        //The end is where the next tile grid will be.
        endPosition = startPosition + Direction * m_Tile / 2;

        float t = 0;

        //Make sure it doesn't go out of bounds.
        if (!(endPosition.x < -1f || endPosition.x > 18 || endPosition.z < -1 || endPosition.z > 18))
        {
            //CHANGE Here cheacking for forward tile is occupied
            if (m_ForwardTile.occupant == null || m_ForwardTile.type != 0 && m_ForwardTile.occupant != null)
            {
                if(m_ForwardTile.occupant != null)
                    m_ForwardTile.occupant.transform.GetChild(0).GetComponent<WalkOver>().ApplyEffect(this.gameObject);

                m_CurrentTile.occupant = null;
                m_ForwardTile.occupant = this.gameObject;
                m_ForwardTile.type = 0;

                //So you can't rotate while moving
                m_canRotate = false;

                //Make sure the object is moving.
                m_isRunning = true;

                while (t < 1f)
                {
                    t += Time.deltaTime * m_Speed;

                    //Lerping it's position from the start to the end.
                    transform.position = Vector3.Lerp(startPosition, endPosition, t);

                    yield return null;
                }

                //Make the objects position to wherever the end will be.
                transform.position = endPosition;

                Vector3 playerpos = transform.position;

                //Using tile's y position or else player is never considered on tile.
                playerpos.y = 0;

                //New current tile
                m_CurrentTile = m_TileManager.GetGridTile(playerpos);

                //CHANGE get forward tile after moved
                m_ForwardTile = m_TileManager.GetNextTile(Direction, m_CurrentTile);

                //Now you can rotate AKA not moving
                m_canRotate = true;
                //Have a delay in between the movement so that animation can blend in.
                yield return new WaitForSeconds(0.02f);

                //Ready for next movement so can't rotate
                m_canRotate = false;
                //Set it back to false and run through the coroutine again.
                m_isRunning = false;
            }
        }
        //If you can't move then you can rotate
        m_canRotate = true;
    }

    public void ApplySpeed()
    {
        m_Speed *= 1.5f;
    }
}

