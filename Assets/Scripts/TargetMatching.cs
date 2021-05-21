using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class TargetMatching : MonoBehaviour
{

    protected Animator animator;

    //the platform object in the scene
    public Transform jumpTarget = null;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animator)
        {
            if (Input.GetButton("Fire1"))
            {
                animator.MatchTarget(jumpTarget.position, // position in world where the model should or would reach at the end of this function
                    jumpTarget.rotation, // rotation the of the Animator GameObject at the end of this function
                    AvatarTarget.LeftFoot, //  which body part will be at the target’s position at the end of the function
                    new MatchTargetWeightMask( // how much priority or masking it from the values received you want to give to the position and rotation
                        Vector3.one, // position 
                        1f), // rotation
                    0.141f, // when to end (in normalized animation duration)
                    0.25f); // when to start (in normalized animation duration)
            }
        }
    }
}