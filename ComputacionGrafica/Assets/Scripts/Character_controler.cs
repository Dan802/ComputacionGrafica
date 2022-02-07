using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Character_controler : MonoBehaviour
{
    [SerializeField] private ParticleSystem Ps_Anticipacion;
    [SerializeField] private ParticleSystem Ps_Escudo;
    public GameObject Escudo;
    public GameObject Anticipacion;
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

            Ps_Anticipacion.Play();

            if (!Ps_Anticipacion.IsAlive())
            {
                Debug.Log("activado");
                Escudo.SetActive(true);
                Ps_Escudo.Play();
            }
        }

        

        if (!defensePressed && isdefending)
        {
            animator.SetBool("Defense", false);
            Escudo.SetActive(false);
        }
    }
}