using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingHand : MonoBehaviour
{
    Animator playerAnim;
    

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (PlayerMove.axel == false)
        {
            if (Input.GetButtonUp("Fire1"))
            {
             playerAnim.SetTrigger("HitHand");
            }
        }
        
    }
}
