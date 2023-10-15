using ModestTree;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Camera mainCamera;

    private Vector2 dir;

    public void OnMove(InputAction.CallbackContext context)
    {
        dir = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        PlayerMove();
        Aim();
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
    }

    private void PlayerMove()
    {
        Vector3 movement = new Vector3(dir.x, 0f, dir.y);

        transform.Translate(movement *  speed * Time.deltaTime, Space.World);
    }

    private void Aim()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
}
