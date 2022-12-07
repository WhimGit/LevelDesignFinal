using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCharacter : MonoBehaviour
{
    private StateMachine meleeStateMachine;
    public Collider2D hitbox;
    
    private void Start()
    {
        meleeStateMachine = GetComponent<StateMachine>();
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.E) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            meleeStateMachine.SetNextState(new GroundEntryState());
        }
    }
}
