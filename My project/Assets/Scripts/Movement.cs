using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private Vector3 velocity;
    [SerializeField]private GameObject ground;
    [SerializeField]private Transform defaultGameObject;
    [SerializeField]private Transform crouchedGameObject;
    [SerializeField]private Transform yereyatanObje;
    [SerializeField]private float jumpForce;
    [SerializeField]private float walkSpeed;
    [SerializeField]private float speed;
    [SerializeField]private float runSpeed;
    [SerializeField]private float distance;
    [SerializeField]private float maxLimit;
    [SerializeField]private float minLimit;
    [SerializeField]private float sensitivity;
    [SerializeField]private float gravity=-9.81f;
    private bool isGrounded;
    [SerializeField]private LayerMask mask;
    private float limit;
    private Vector3 currentPos;
    private Camera mainCam;
    void Start()
    {
        controller=GetComponent<CharacterController>();
        mainCam=Camera.main;
        UnityEngine.Cursor.visible= false;
        UnityEngine.Cursor.lockState=CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded=Physics.CheckSphere(ground.transform.position,distance,(int)mask);
        if(isGrounded && velocity.y<0){
            velocity.y =-2f;
        }
        float x=Input.GetAxisRaw("Horizontal");
        float y=Input.GetAxisRaw("Vertical");
        float x_look=Input.GetAxisRaw("Mouse X");
        float y_look=Input.GetAxisRaw("Mouse Y");
       limit+=y_look;
       limit =Mathf.Clamp(limit,minLimit,maxLimit);
        mainCam.transform.localEulerAngles=new Vector3(-limit,0,0);
        transform.Rotate(transform.up*(x_look*sensitivity*Time.deltaTime));
       speed=Input.GetKey(KeyCode.LeftShift)?runSpeed:walkSpeed;
       currentPos=Input.GetKey(KeyCode.Z)?yereyatanObje.transform.position:defaultGameObject.transform.position;
        currentPos=Input.GetKey(KeyCode.C)?crouchedGameObject.transform.position:currentPos;
       

       float step=2f*Time.deltaTime;
        mainCam.transform.position=Vector3.MoveTowards(mainCam.transform.position,currentPos,step);
        Vector3 direction=transform.right*x+transform.forward*y;
        controller.Move(direction*(speed*Time.deltaTime));
        if(Input.GetButtonDown("Jump")&& isGrounded){
            velocity.y=Mathf.Sqrt(gravity*-2f*jumpForce);
        }
        velocity.y += gravity*Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

    }
}
