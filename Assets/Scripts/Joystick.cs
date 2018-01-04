using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private MoveByJoystick playerMove;

    // Use this for initialization
    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<MoveByJoystick>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Left")
        {
            playerMove.MoveLeft = true;
        }
        else
        {
            playerMove.MoveRight = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerMove.StopMoving();
    }
}
