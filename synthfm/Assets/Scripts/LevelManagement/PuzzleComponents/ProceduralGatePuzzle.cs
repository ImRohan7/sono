﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGatePuzzle : Puzzle
{
    public int gateCount = 5;
    [SerializeField]
    private int currentGate = 0;
    public float radius = 100f;

    private float puzzleX;
    private float puzzleY;

    // Start is called before the first frame update
    public new void DoSetup()
    {
        base.DoPuzzleSetup();
        SpawnGate();
    }


    private void Awake()
    {
        puzzleX = this.transform.position.x;
        puzzleY = this.transform.position.y;
    }
    void SpawnGate()
    {
        //clone a gate prefab
        GameObject gate = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Puzzles/Gate"));
        gate.transform.parent = this.transform; //make child of this object (for trigger)
        gate.GetComponent<GateTrigger>().setPartOfPuzzle(true);
        gate.GetComponent<GateTrigger>().setIgnoreAngle(true);

        //random position within our radius
        float xDist = Random.Range(-radius, radius);
        float yDist = Random.Range(-radius, radius);

        gate.transform.position = new Vector3(puzzleX + xDist, puzzleY + yDist, 0);

        //random rotation for the gate
        float angle = Random.Range(0, 360);
        gate.transform.eulerAngles = new Vector3(0, 0, angle);

        Debug.Log("Gate spawned at " + gate.transform.position.ToString());


    }

    public override void GateTriggered(GateTrigger trigger)
    {
        if (complete) { return; }

        //deactivate this gate and spawn a new one
        Destroy(trigger.gameObject);
        if (currentGate < gateCount)
        {
            SpawnGate();
            currentGate++;
        }
        if (currentGate == gateCount)
        {
            Debug.Log("Puzzle complete!");
            complete = true;
            DeleteForcefield();

        }
    }

    public void DeleteForcefield()
    {

        GateTrigger[] gates = GetComponentsInChildren<GateTrigger>();
        foreach(GateTrigger gate in gates)
        {
            Destroy(gate.gameObject);
        }

        base.ReleaseCage();
    }

}
