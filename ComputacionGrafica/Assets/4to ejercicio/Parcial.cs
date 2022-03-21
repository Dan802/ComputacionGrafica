using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcial : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem particles;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (particles.IsAlive()== false)
        {
            animator.SetBool("Parcial", false);
        }
    }

    public void Play ()
    {
        animator.SetBool("Parcial", true);
        particles.Play();
    }
}
