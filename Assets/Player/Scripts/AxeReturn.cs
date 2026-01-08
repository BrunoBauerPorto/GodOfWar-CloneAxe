using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeReturn : MonoBehaviour
{
    Animator animPlayer;
    public Rigidbody axe;
    public float throwForce = 1000f;
    public Transform target, curve_point, parentReturn;
    private Vector3 old_pos;
    public static bool isReturning = false;
    public bool isThrow = false;
    public bool launchAxe = false;
    
    private float time = 0.0f;


    private void Start()
    {
        animPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            animPlayer.SetBool("AxelThrow", true);
            PlayerMove.axel = false;
            
        }   else animPlayer.SetBool("AxelThrow", false);
              
               
        if (Input.GetKeyDown(KeyCode.R) && PlayerMove.axel == false)
        {
            ReturnAxe();
        }

       
        if(isReturning)
        {
            if (time < 1.0f)
            {
                axe.position = getBQCPoint(time, old_pos, curve_point.position, target.position);
                axe.rotation = Quaternion.Slerp(axe.transform.rotation, target.rotation, 50 * Time.deltaTime);
                time += Time.deltaTime;
            }
            else ResetAxe();
        }
    }

   
    public void ThrowAxe()
    {
        isReturning = false;
        axe.transform.parent = null;
        axe.isKinematic = false;
        axe.AddForce(Camera.main.transform.TransformDirection(Vector3.forward) * throwForce, ForceMode.Impulse);
        axe.AddTorque(axe.transform.TransformDirection(Vector3.back) * 25000, ForceMode.Acceleration);
    }

    void ReturnAxe()
    {
        time = 0.0f;
        old_pos = axe.position;
        axe.AddTorque(axe.transform.TransformDirection(Vector3.back) * 25000, ForceMode.Acceleration);
        isReturning = true;
        axe.linearVelocity = Vector3.zero;
        axe.isKinematic = true;
       
    }
    void ResetAxe()
    {
        isReturning = false;
        axe.transform.parent = parentReturn;
        axe.position = target.position;
        axe.rotation = target.rotation;
        PlayerMove.axel = true;
        
    }

    Vector3 getBQCPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = (uu * p0) + (2* u * t * p1) + (tt * p2);
        return p;
    }
}
