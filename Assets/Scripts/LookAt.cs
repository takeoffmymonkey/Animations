using UnityEngine;
using System.Collections;

/*
 Плавно поворачивает куб в сторону шара, когда перемещаешь КУБ (в эдиторе)
 */


[ExecuteInEditMode]
public class LookAt : MonoBehaviour
{

    private Transform ThisTransform = null; //Cached transform
    public Transform Target = null; //Target to look at
    public float RotateSpeed = 100f; //Rotate speed


    void Awake()
    {
        ThisTransform = GetComponent<Transform>();
    }


    void Start()
    {
        StartCoroutine(TrackRotation(Target)); //Start tracking target
    }


    //Coroutine for turning to face target
    IEnumerator TrackRotation(Transform Target)
    {
        //Loop forever and track target
        while (true)
        {
            if (ThisTransform != null && Target != null)
            {
                //Get direction to target
                Vector3 relativePos = Target.position - ThisTransform.position;
                //Calculate rotation to target
                Quaternion NewRotation = Quaternion.LookRotation(relativePos);
                //Rotate to target by speed
                ThisTransform.rotation = Quaternion.RotateTowards(ThisTransform.
                rotation, NewRotation, RotateSpeed * Time.deltaTime);
            }
            //wait for next frame
            yield return null;
        }
    }

    //Function to draw look direction in viewport
    void OnDrawGizmos()
    {
        Gizmos.DrawLine(ThisTransform.position, ThisTransform.forward.
        normalized * 5f);
    }
}