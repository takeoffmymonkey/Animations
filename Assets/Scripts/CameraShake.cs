using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 Этот пример кода использует сопрограммы для случайного коле-
бания камеры в воображаемой сфере, определяемой с помощью пере-
менной Random.insideUnitSphere.
 */

public class CameraShake : MonoBehaviour
{
    private Transform ThisTransform = null;

    public float ShakeTime = 2.0f; //Total time for shaking in seconds
    public float ShakeAmount = 3.0f; //Shake amount - distance to offset in any direction
    public float ShakeSpeed = 2.0f; //Speed of camera moving to shake points
    
    void Start()
    {
        ThisTransform = GetComponent<Transform>();
        StartCoroutine(Shake());
    }
    
    //Shake camera
    public IEnumerator Shake()
    {
        //Store original camera position
        Vector3 OrigPosition = ThisTransform.localPosition;
        //Count elapsed time (in seconds)
        float ElapsedTime = 0.0f;
        //Repeat for total shake time

        while (ElapsedTime < ShakeTime)
        {
            //Pick random point on unit sphere
            Vector3 RandomPoint = OrigPosition + Random.insideUnitSphere *
            ShakeAmount;
            //Update Position
            ThisTransform.localPosition = Vector3.Lerp(ThisTransform.
            localPosition, RandomPoint, Time.deltaTime * ShakeSpeed);
            //Break for next frame
            yield return null;
            //Update time
            ElapsedTime += Time.deltaTime;
        }
        //Restore camera position
        ThisTransform.localPosition = OrigPosition;
    }
}