﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentCase : MonoBehaviour
{
    public int fragmentNumber;
    public FragmentController fragment;

    private void Start()
    {
       // fragment = Instantiate(LevelManager.instance.fragmentPrefab, transform).GetComponent<FragmentController>();
        fragment.SetClip(LevelManager.instance.audioFragments[fragmentNumber]);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TO DO: Make this not grabbable after it is deposited
        if(collision.gameObject == LevelManager.instance.getPlayer())
        {
            if (fragment.currentState != FragmentController.states.DEPOSIT)
            {
                fragment.Collect(LevelManager.instance.getPlayer().transform);
            }

        }
       
    }

    public FragmentController getFragment()
    {
        return fragment;
    }
}
