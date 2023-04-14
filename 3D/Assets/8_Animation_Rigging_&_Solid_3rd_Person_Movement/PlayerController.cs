using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rBody;
    [SerializeField] private float speed = 3f;

    private bool isRunning = false;
    private float horizInput;

    void Start()
    {
        animator = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizInput = Input.GetAxis("Horizontal");

        // 0: No Key, -1: Left Key, +1: Right Key
        if (Mathf.Abs(horizInput) > 0.01f)
        {
            // Move Character
            transform.rotation = Quaternion.LookRotation(new Vector3(horizInput, 0f, 0f));
            rBody.MovePosition(rBody.position - transform.forward * speed * Time.deltaTime);


            // Change Anim
            if (!isRunning)
            {
                isRunning = true;
                animator.SetBool("isRunning", true);
            }
        }
        else if (isRunning)
        {
            isRunning = false;
            animator.SetBool("isRunning", false);
        }

    }
}
