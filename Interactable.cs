using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool interacting{get;private set;}
    void Start(){
        interacting = false;
    }
    public virtual void Interact(){
        interacting = true;
        Debug.Log("Interacting");
    }
    public virtual void Exit(){
        interacting = false;
    }
}
