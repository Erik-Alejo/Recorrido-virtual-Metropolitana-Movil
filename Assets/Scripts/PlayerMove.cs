using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public FixedJoystick joystick;
    public float SpeedMove = 5f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Buscar autom�ticamente el joystick si no est� asignado
        if (joystick == null)
        {
            joystick = FindObjectOfType<FixedJoystick>();
        }
    }

    void Update()
    {
        // Evitar errores si joystick o controller no existen a�n
        if (joystick == null || controller == null)
            return;

        Vector3 Move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        controller.Move(Move * SpeedMove * Time.deltaTime);
    }
}
