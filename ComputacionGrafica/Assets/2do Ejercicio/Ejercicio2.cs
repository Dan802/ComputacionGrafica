using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio2 : MonoBehaviour
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
        if( Input.GetKey("e"))
        {
            animator.SetBool("Rayo", true);
        }
        else
        {
            animator.SetBool("Rayo", false);
        }
        

        if(Input.GetKeyDown("e"))
        {
            particles.Play();
        }
    }

    public void VFX ()
    {
        
    }
}
