using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State CurrentState => _currentState;
    protected bool InTransition { get; private set; }

    State _currentState;
    protected State _previousState;

    public void ChangeState<T>() where T : State
    {
        T targetState = GetComponent<T>();
        if (targetState == null)
        {
            Debug.LogWarning("Cannot change to state, as it does not exist on the State Machien Object."
            + " Make sure you have the desired State attached to the State Machine!");
            return;
        }
        // otherwise, we found our state
        InitiateStateChange(targetState);
    }

    public void RevertState()
    {
        if(_previousState != null)
        {
            InitiateStateChange(_previousState);
        }
    }

    public void InitiateStateChange(State targetState)
    {
        // if new state is different and not transitioning, continue
        if(_currentState != targetState && !InTransition)
        {
            Transition(targetState);
        }
    }

    void Transition(State newState)
    {
        // start
        InTransition = true;
        // transitioning
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
        // end
        InTransition = false;
    }

    private void Update()
    {
        // simulate Update in States with 'tick'
        if(CurrentState != null && !InTransition)
        {
            CurrentState.Tick();
        }
    }
}
