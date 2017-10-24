using UnityEngine;
using System.Collections;

public class Player : BasePlayer
{
    public Color playerColor = Color.red;
    public Vector3 pDirection;
    public bool isBot;
    public string powerUp { get; set; }

    [SerializeField]
    GameObject[] usePowerUp;

    protected override void Start()
    {
        base.Start();
        color = playerColor;
        powerUp = "";
        m_Speed = 1;
        Direction = pDirection;
        m_CurrentTile = m_TileManager.GetGridTile(new Vector3(transform.position.x, 0, transform.position.z));

        //CHANGE set up forward tile
        m_ForwardTile = m_TileManager.GetGridTile(new Vector3(transform.position.x, 0, transform.position.z) + (transform.forward * 2.5f));
    }

    protected override void Update()
    {
        UseItemCheck();
        RotatePlayer();
        KeyboardControls();
        base.Update();
        //Changes the tile colour;
        m_TileManager.ChangeColors(color, m_CurrentTile);
    }

    public TileManager GetTileManager()
    {
        return m_TileManager;
    }

    public void AddScore(int aScore)
    {
        m_Score += aScore;
    }

    //TODO possibly take this out of update
    void UseItemCheck()
    {
        if (PickUp.m_useItem == true)
        {
            if (Input.GetButton("AButtonFire") || Input.GetKeyDown(KeyCode.Space))
            {
                GameObject particle = null;
                if (powerUp == "Electric")
                {
                    particle = usePowerUp[0];
                }
                else if (powerUp == "Missile")
                {
                    particle = usePowerUp[2];
                }

                GameObject Shoot = Instantiate(particle);

                Shoot.transform.position = transform.position + transform.forward;

                Shoot.transform.rotation = transform.rotation;

                Shoot.transform.forward = this.gameObject.transform.forward;

                Shoot.AddComponent<Missile>();

                PickUp.m_useItem = false;
            }
        }
    }
}
