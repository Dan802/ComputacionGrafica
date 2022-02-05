using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Character_controler : MonoBehaviour
{
    [SerializeField] private Rigidbody rigibodyNinja;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool iswalking = Input.GetKeyDown("w");
        //bool isrunning = Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown("w");

        if (Input.GetKeyDown("w"))
        {
            animator.SetBool("Walking", true);
            animator.SetBool("Running", false);
            animator.SetBool("Idle", false);
        }
        
        if(Input.GetKeyUp("w"))
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Idle", true);
        }

        //if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown("w"))
        //{
        //    animator.SetBool("Walking", false);
        //    animator.SetBool("Running", true);
        //    animator.SetBool("Idle", false);
        //}
        //else
        //{
        //    animator.SetBool("Idle", true);
        //}


        /*if (isrunning == false && iswalking == false)
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Running", false);
            animator.SetBool("Idle", true);
        }*/
    }
}
