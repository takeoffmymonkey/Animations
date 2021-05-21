using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Это как доп график времени/значения, которые можно применить в рассчетах.
Здесь у нас есть график на 5 сек с ростом, а потом с падением скорости. В итоге, объект сначала ускоряется от 0, а потом замедляется к 0 за 5 сек
 */

public class AnimCurveMover : MonoBehaviour
{
    public float Speed = 1f; //Maximum Speed to travel (in metres) per second
    public Vector3 Direction = Vector3.zero; //Direction to travel
    public AnimationCurve AnimCurve; //Curve to adjust speed (horizontal = time, vertical = speed)

    void Update()
    {
        Transform ThisTransform = GetComponent<Transform>();
        
        //Update position in specified direction by speed
        ThisTransform.position += Direction.normalized * Speed * 
            AnimCurve.Evaluate(Time.time) * Time.deltaTime;
    }
}
