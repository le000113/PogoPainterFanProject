using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{

    public static InputManager sInstance;

    // Use this for initialization
    void Awake()
    {
        if (sInstance == null)
        {
            sInstance = this;
        }
        else
        {
            Debug.Log("You have more than 1 manager");
        }

        DontDestroyOnLoad(gameObject);
    }

    public Vector3 MoveHorizontal
    {
        get
        {
            return new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        }
    }

    public Vector3 MoveVertical
    {
        get
        {
            return new Vector3(0, 0, Input.GetAxis("Vertical"));
        }
    }

    public Vector3 InputControllerHorizontal
    {
        get
        {
            return new Vector3(0, 0, 0); //TODO fix this.
        }
    }

    public Vector3 InputControllerVertical
    {
        get
        {
            return new Vector3(0, 0, 0);
        }
    }
}
