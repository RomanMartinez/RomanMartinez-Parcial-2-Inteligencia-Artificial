using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMachine : MonoBehaviour
{
    private IState _currentState;
    private Dictionary<NpcStates, IState> _allStates = new Dictionary<NpcStates, IState>();

    public void Update()
    {
        _currentState.OnUpdate();
    }

    public void ChangeState(NpcStates state)
    {
        if (!_allStates.ContainsKey(state)) return;

        if (_currentState != null) _currentState.OnExit();
        _currentState = _allStates[state];
        _currentState.OnStart();
    }
    public void AddState(NpcStates key, IState value)
    {
        if (!_allStates.ContainsKey(key)) _allStates.Add(key, value);
        else _allStates[key] = value;
    }

}
