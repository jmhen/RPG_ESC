﻿using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : NetworkBehaviour
{
    public LayerMask movementMask;
    public Interactable focus;
    Camera cam;
    PlayerMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();

    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                //Debug.Log("We hit " + hit.collider.name +" "+hit.point);
                RemoveFocus();
                motor.MoveToPoint(hit.point);
                //move player to waht we hit
            }
            if (Physics.Raycast(ray, out hit, 100)) // Do not put movementMask here
            {
                //check if we hit an interatable
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                //if yes, set it as our focus
                if (interactable != null)
                {
                    SetFocus(interactable);
                    //Debug.Log("We hit Interactable" + hit.collider.name + " " + hit.point);
                }
                else
                {
                    Debug.Log("Interactable not detected");
                }

            }
        }



    }
    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if (focus != null) { focus.OnDefocused(); }

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
   
        newFocus.OnFocused(transform);
       
    }

    void RemoveFocus()
    {
        if (focus != null) { focus.OnDefocused(); }
        focus = null;

        motor.StopFollowingTarget();
    }
}
