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

        // Buscar automáticamente el joystick si no está asignado
        if (joystick == null)
        {
            joystick = FindObjectOfType<FixedJoystick>();
        }
    }

    void Update()
    {
        // Evitar errores si joystick o controller no existen aún
        if (joystick == null || controller == null)
            return;

        Vector3 Move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        controller.Move(Move * SpeedMove * Time.deltaTime);
    }
}
