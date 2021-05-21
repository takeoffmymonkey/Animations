using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReceiver : MonoBehaviour
{
    private void PrivateEvent()
    {
        Debug.Log("PrivateEvent");
    }

    //public void PublicEvent()
    //{
    //    Debug.Log("PublicEvent");
    //}

    public void PublicEvent(int number)
    {
        Debug.Log("PublicEvent + number: " + number);
    }
}
