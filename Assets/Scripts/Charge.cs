using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    private bool m_Charge = false;
    private Rigidbody rb;
    private int direction;
    private float chargeTime;
    public float startChargeTime;
    private float m_walkSpeed;
    private float m_turnSpeed;
    public float chargeSpeed;
    private float m_chargeTurn = 3.0f; 
    public KeyCode chargeKey = KeyCode.LeftShift;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        chargeTime = startChargeTime;
    }

    // Update is called once per frame
    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(chargeKey))
        {
            m_Charge = !m_Charge;

            CheckCharge();
        }

        if (direction == 0)
        {
            if (Input.GetKeyDown(chargeKey))
            {
                direction = 1; 
            }

        }
        else
        {
            if (chargeTime <= 0)
            {
                direction = 0;
                chargeTime = startChargeTime;
                rb.velocity = Vector3.zero;
            }
            else
            {
                chargeTime -= Time.deltaTime;
            }
            if(direction == 1)
            {
                rb.AddForce(transform.forward * chargeSpeed, 0, horizontalInput * m_chargeTurn, ForceMode.Force);
            }
        }
    }

    void CheckCharge()
    {

    }
}
