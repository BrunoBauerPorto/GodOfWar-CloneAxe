using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingAxe : MonoBehaviour
{
    Animator playerAnim;
    public GameObject axe;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }

    private void Update()
    {

        if (PlayerMove.axel == true)
        {
            axe.SetActive(true);
            if (Input.GetButtonUp("Fire1"))
            {
                playerAnim.SetTrigger("AxeAttack");
            }

        }

        
       
    }
}
