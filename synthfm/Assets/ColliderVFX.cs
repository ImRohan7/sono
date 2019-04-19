﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class ColliderVFX : MonoBehaviour
{
    public VisualEffect Fragmentget;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fragmentget.SetBool("Collison", true);
        Fragmentget.SendEvent("Collided");
        print("Trigga");
        Fragmentget.SetInt("Switch", 1);
        Fragmentget.SetFloat("Range", -3);
        anim.SetTrigger("PickedUp");
    }


}