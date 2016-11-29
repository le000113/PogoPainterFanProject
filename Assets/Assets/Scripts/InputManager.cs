using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    //Make it global.
    public static InputManager sInstance;

    void Awake()
    {
        //Check to see if it's null, if it is make it this.
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
            return new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        }
    }

    public Vector3 MoveVertical
    {
        get
        {
            return new Vector3(0, 0, Input.GetAxisRaw("Vertical"));
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
