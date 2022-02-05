using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Character_controler : MonoBehaviour
{
    //[SerializeField] private Rigidbody rigibodyNinja;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool iswalking = animator.GetBool("Walking");
        bool runPressed = Input.GetKey("left shift");
        bool isrunning = animator.GetBool("Running");

        if (!iswalking && forwardPressed)
            animator.SetBool("Walking", true);

        if (iswalking && !forwardPressed)
            animator.SetBool("Walking", false);

        if (!isrunning && forwardPressed && runPressed)
            animator.SetBool("Running", true);

        if (isrunning && (!forwardPressed || !runPressed))
            animator.SetBool("Running", false);
    }
}