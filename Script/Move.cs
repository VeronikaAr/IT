using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float jump;
    [SerializeField] float speed;
    bool Earth;
    Rigidbody rd;
    Vector3 derection;

    void Start()
    {
        rd = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        rd.MovePosition(transform.position + derection * speed * Time.fixedDeltaTime);
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        derection = transform.TransformDirection(x, 0, y);

        if (Earth)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rd.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
            }
        }
        
    }
    private void OnCollisionStay(Collision other)
    {
        if(other != null)
        {
            Earth = true;
        }
    }
}
