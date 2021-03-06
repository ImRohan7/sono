﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifierP : MonoBehaviour
{
    public int seqNo;
    public PuzzleManager puzzleManager;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!(this.gameObject.name == "Rock"))
        {
            Crystal _crystal = this.gameObject.GetComponent<Crystal>();
            if ((_crystal._state == PuzzleManager.State.OFF)) 
            {
                puzzleManager.Notify(this);
            }
        }
        else // if it is a rock
        {
            RockIt _rock = this.gameObject.GetComponent<RockIt>();
            if(!_rock.ToDeactivate)
            {
                puzzleManager.Notify(this);
            }
        }
    }

}
