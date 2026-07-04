using UnityEngine;
using UnityEngine.InputSystem;

public class RotatePlayer : MonoBehaviour
{
    [SerializeField] InputAction rotatePlayer;

    [SerializeField] float rotationSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotatePlayer.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (rotatePlayer.IsPressed())
        {
            if (rotatePlayer.ReadValue<float>() > 0)
                transform.Rotate(Vector3.up, rotationSpeed * 1);
            else
            {
                transform.Rotate(Vector3.up, rotationSpeed * -1);
            }
        }
    }
}
