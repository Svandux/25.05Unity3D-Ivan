using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float gravityScale = 9.8f, speedScale = 5f, jumpForce = 2f, turnSpeed = 90f;
    private float verticalSpeed = 0f, mouseX = 0f, mouseY = 0f, CurrentAngleX = 0f;
    private CharacterController controller;
    [SerializeField] private Camera Cam;
    [SerializeField] private GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        RotateCharacter();
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }

    void RotateCharacter()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(0f, mouseX * turnSpeed * Time.deltaTime, 0f));
        CurrentAngleX += mouseY * turnSpeed * Time.deltaTime * -1f;
        CurrentAngleX = Mathf.Clamp(CurrentAngleX, -60f, 60f);
        Cam.transform.localEulerAngles = new Vector3(CurrentAngleX, 0f, 0f);
    }

    void MoveCharacter()
    {
        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        velocity = transform.TransformDirection(velocity) * speedScale;
        if (controller.isGrounded)
        {
            verticalSpeed = 0f;
            if (Input.GetButton("Jump"))
            {
                verticalSpeed = jumpForce;
            }
        }
        verticalSpeed -= gravityScale * Time.deltaTime;
        velocity.y = verticalSpeed;
        controller.Move(velocity * Time.deltaTime);
    }


}
