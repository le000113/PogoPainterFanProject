using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    public void DeleteObject(GameObject obj, bool isActive, float timer)
    {
       if(isActive == true)
        {
            Destroy(obj, timer);
        }
    } 
}
