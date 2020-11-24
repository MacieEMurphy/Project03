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
    Vector3 mainCam;
    AudioSource audioSource = null;

    [SerializeField] Transform thirdPersonPosition;
    [SerializeField] Transform firstPersonPosition;
    [SerializeField] AudioClip chargeSFX = null;

    public PlayerController playerController;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
                Camera.main.transform.position = thirdPersonPosition.position;
                playerController.SetBoosters(true);
                if (audioSource != null && chargeSFX != null)
                {
                    audioSource.clip = chargeSFX;
                    audioSource.Play();
                }

            }

        }
        else
        {
            if (chargeTime <= 0)
            {
                direction = 0;
                chargeTime = startChargeTime;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                Camera.main.transform.position = firstPersonPosition.position;
                playerController?.SetBoosters(false);
            }
            else
            {
                chargeTime -= Time.deltaTime;
                
            }
            if(direction == 1)
            {
                
                rb.AddForce(transform.forward * chargeSpeed);
                if (Input.GetKey(KeyCode.A))
                {
                    rb.AddRelativeForce(Vector3.left * m_chargeTurn);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    rb.AddRelativeForce(Vector3.right * m_chargeTurn);
                }
            }
        }
    }

    void CheckCharge()
    {

    }

}
