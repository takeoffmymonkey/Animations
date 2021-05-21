using UnityEngine;
using System.Collections;
public class NinjaBlendTree : MonoBehaviour
{
    //Animator Controller
    private Animator ThisAnimator = null;
    //Float names
    private int HorzFloat = Animator.StringToHash("Horiz");
    private int VertFloat = Animator.StringToHash("Vert");
    
    void Awake()
    {
        ThisAnimator = GetComponent<Animator>();
    }
 
    void Update()
    {
        //Read player input
        float Vert = Input.GetAxis("Vertical");
        float Horz = Input.GetAxis("Horizontal");
        //Set animator floating point values
        ThisAnimator.SetFloat(HorzFloat, Horz, 0.2f, Time.deltaTime);
        ThisAnimator.SetFloat(VertFloat, Vert, 0.2f, Time.deltaTime);
    }
}