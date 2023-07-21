using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera camera;
    void Update(){
        RaycastHit hitCenter;
        if(Physics.Raycast(camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)), out hitCenter, 3)){
            Interactable interactable = hitCenter.collider.GetComponent<Interactable>();
            if((Input.GetKeyDown(KeyCode.LeftControl)||Vector3.Distance(transform.position,GameObject.FindObjectOfType<NPC>().transform.position)<=2f&&interactable!=null)){
                if(!interactable.interacting){
                    interactable.Interact();
                }
            }
        }
    }
}
