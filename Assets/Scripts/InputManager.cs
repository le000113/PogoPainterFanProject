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
            Debug.Log("You have more than 1 manager");

        DontDestroyOnLoad(gameObject);
    }

    public Vector3 InputControllerHorizontal(string pHorizontal)
    {
        return new Vector3(Input.GetAxisRaw(pHorizontal), 0, 0);
    }

    public Vector3 InputControllerVertical(string pVertical)
    {
        return new Vector3(0, 0, Input.GetAxisRaw(pVertical));
    }

}
