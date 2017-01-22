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

    public Vector3 InputControllerHorizontalP1
    {
        get
        {
            return new Vector3(Input.GetAxisRaw("P1Horiztonal"), 0, 0);
        }
    }

    public Vector3 InputControllerVerticalP1
    {
        get
        {
            return new Vector3(0, 0, Input.GetAxisRaw("P1Vertical"));
        }
    }

    public Vector3 InputControllerHorizontalP2
    {
        get
        {
            return new Vector3(Input.GetAxisRaw("P2Horizontal"), 0, 0); 
        }
    }

    public Vector3 InputControllerVerticalP2
    {
        get
        {
            return new Vector3(0, 0, Input.GetAxisRaw("P2Vertical"));
        }
    }

}
