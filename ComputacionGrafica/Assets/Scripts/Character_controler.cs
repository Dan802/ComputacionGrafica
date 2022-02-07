using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Character_controler : MonoBehaviour
{
    [SerializeField] private ParticleSystem Ps_Anticipacion;
    [SerializeField] private ParticleSystem Ps_Escudo;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator particles;

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
        bool defensePressed = Input.GetKey("f");
        bool isdefending = animator.GetBool("Defense");

        if (!iswalking && forwardPressed)
            animator.SetBool("Walking", true);

        if (iswalking && !forwardPressed)
            animator.SetBool("Walking", false);

        if (!isrunning && forwardPressed && runPressed)
            animator.SetBool("Running", true);

        if (isrunning && (!forwardPressed || !runPressed))
            animator.SetBool("Running", false);

        if (defensePressed && !isdefending)
        {
            animator.SetBool("Defense", true);
        }

        if (!defensePressed && isdefending)
        {
            animator.SetBool("Defense", false);
        }
    }

    public void Primero ()
    {
        Ps_Anticipacion.Play();
    }

    public void Segundo ()
    {
        Ps_Escudo.Play();
        particles.SetBool("Begin", true);

        //AnimatorStateTransition.hasExitTime = true;
    }
}