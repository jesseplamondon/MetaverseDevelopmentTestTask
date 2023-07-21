using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : Interactable
{
    private NPCStateMachine stateMachine;
    void Start()
    {
        stateMachine = new NPCStateMachine();
    }
    void Update()
    {
        stateMachine.currentState.Execute();
    }
    public override void Interact(){
        base.Interact();
        //go talking state
        stateMachine.ChangeState(State.States.Talking);
    }
    public override void Exit(){
        //go to roaming state
        stateMachine.ChangeState(State.States.Roaming);
    }
}
public class NPCStateMachine
{
    public State currentState { get; private set;}
    public NPCStateMachine()
    {
        currentState = new Roaming();
        currentState.Enter();
    }
    public void ChangeState(State.States newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = (State)Activator.CreateInstance(Type.GetType(newState.ToString()));
        currentState.Enter();
    }
}
public class State
{
    public enum States { Roaming, Talking}
    protected NPC npc;
    protected string animationString = "";
    public virtual void Enter()
    {
        npc = GameObject.FindObjectOfType<NPC>();
        npc.GetComponent<Animator>().SetBool(animationString, true);
    }
    public virtual void Execute(){}
    
    public virtual void Exit()
    {
        npc.GetComponent<Animator>().SetBool(animationString, false);
    }
}
public class Roaming : State
{
    private Vector3 destination;
    public override void Enter()
    {
        animationString = "roaming";
        base.Enter();
    }
    public override void Execute()
    {
        if(Vector3.Distance(npc.transform.position, destination)<=0.5f)
        {
            destination = GetLocation();
            npc.GetComponent<NavMeshAgent>().SetDestination(destination);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
    private Vector3 GetLocation()
    {
        //set agent destination to random destination on navmesh
        return Vector3.zero;//temp
        
    }
}
public class Talking : State
{
    public override void Enter()
    {
        animationString = "talking";
        base.Enter();
    }
}
