using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : IState
{
    FSMachine _fsm;

    public Idle(FSMachine fsm)
    {
        _fsm = fsm;
    }

    public void OnStart()
    {
        Debug.Log("Entre a Idle");
    }

    public void OnUpdate()
    {
        Debug.Log("Estoy en Idle");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _fsm.ChangeState(NpcStates.Patrol);
        }
    }

    public void OnExit()
    {

    }
}
