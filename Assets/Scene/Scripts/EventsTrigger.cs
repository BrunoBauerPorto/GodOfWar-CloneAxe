using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsTrigger : MonoBehaviour
{
    public Animator gateAnim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Axe"))
        {
            gateAnim.SetBool("OpenGate", true);
        }
    }
}
