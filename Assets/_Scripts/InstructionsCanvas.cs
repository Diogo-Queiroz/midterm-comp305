using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsCanvas : MonoBehaviour
{
    private Animator anim;

    public bool instructionsKey = false;

    public bool interactionKey = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("ActivateInstructions", instructionsKey);
        anim.SetBool("ActivateInteractKey", interactionKey);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            instructionsKey = true;
            anim.SetBool("ActivateInstructions", instructionsKey);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionKey = true;
            anim.SetBool("ActivateInteractKey", interactionKey);
        }
    }
}
