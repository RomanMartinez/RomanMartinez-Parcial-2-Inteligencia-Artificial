using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum NpcStates
{
    Idle,
    Patrol
}
public class NPCs : MonoBehaviour
{
    private FSMachine _FSM;

    public GameObject[] allWaypoints;
    public float speed = 5;

    private void Start()
    {
        _FSM = new FSMachine();
        var idle = new Idle(_FSM);

        _FSM.AddState(NpcStates.Idle, idle);
        _FSM.AddState(NpcStates.Patrol, new Patrol(_FSM, this));
        _FSM.ChangeState(NpcStates.Idle);

        ChangeColor(Color.gray);
    }

    private void Update()
    {
        _FSM.Update();
    }

    public void ChangeColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }
}
