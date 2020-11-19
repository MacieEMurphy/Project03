using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    private bool m_Charge = false;
    private float m_walkSpeed;
    private float m_turnSpeed;
    private float m_chargeSpeed = 10.0f;
    private float m_chargeTurn = 3.0f; 
    public KeyCode chargeKey = KeyCode.LeftShift;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(chargeKey))
        {
            m_Charge = !m_Charge;

            CheckCharge();
        }
    }

    void CheckCharge()
    {

    }
}
