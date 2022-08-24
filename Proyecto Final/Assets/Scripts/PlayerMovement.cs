using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 10f)]
    private float speed = 3f;
    private float cameraAxisX = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        RotatePlayer();
        PlayerInputs();
    }

    private void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void PlayerInputs()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MovePlayer(Vector3.forward);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            MovePlayer(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            MovePlayer(Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            MovePlayer(Vector3.back);
        }
    }

    public void RotatePlayer()
    {
        cameraAxisX += Input.GetAxis("Mouse X");
        Quaternion newRotation = Quaternion.Euler(0, cameraAxisX, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2.5f * Time.deltaTime);
    }
}
