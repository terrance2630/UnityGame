using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    public float moveSpeed = 0.5f;
    public float runMultiplierMax = 1.5f;
    private float runMultiplier;

    private Transform cameraTransform;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Start ()
    {
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
        cameraTransform = Camera.main.transform;
    }

    void FixedUpdate ()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
        


        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        m_Movement = cameraTransform.forward * m_Movement.z + cameraTransform.right * m_Movement.x; 
        m_Movement.y = 0f;

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        m_Animator.SetBool ("IsWalking", isWalking);
        m_Animator.SetBool ("IsRunning", isRunning);


        if (isRunning){
            runMultiplier = Random.Range(1.0f, runMultiplierMax);
            m_Movement = runMultiplier * m_Movement;
        }
        
        

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);
    }

    void OnAnimatorMove ()
    {
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * moveSpeed);
        m_Rigidbody.MoveRotation (m_Rotation);
    }
}
