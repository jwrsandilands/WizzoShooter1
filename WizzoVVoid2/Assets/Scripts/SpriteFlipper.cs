using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    // variable to hold a reference to our SpriteRenderer component
    private Animator anim;

    // This function is called just one time by Unity the moment the component loads
    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        anim = GetComponent<Animator>();
    }

    // This function is called by Unity every frame the component is enabled
    private void Update()
    {
        // if the A key was pressed this frame
        if (Input.GetKeyDown(KeyCode.A))
        {
            //unset the rest
            anim.SetBool("Right", false);
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);
            //change dir
            anim.SetBool("Left", true);
        }
        // if the D key was pressed this frame
        if (Input.GetKeyDown(KeyCode.D))
        {
            //unset the rest
            anim.SetBool("Left", false);
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);
            //change dir
            anim.SetBool("Right", true);
        }
        // if the W key was pressed this frame
        if (Input.GetKeyDown(KeyCode.W))
        {
            //unset the rest
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
            anim.SetBool("Down", false);
            //change dir
            anim.SetBool("Up", true);
        }
        // if the S key was pressed this frame
        if (Input.GetKeyDown(KeyCode.S))
        {
            //unset the rest
            anim.SetBool("Right", false);
            anim.SetBool("Up", false);
            anim.SetBool("Left", false);
            //change dir
            anim.SetBool("Down", true);
        }
    }
}
