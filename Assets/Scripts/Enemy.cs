using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] int enemyHealth = 5;

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Physical")
        {
            Debug.Log(enemyHealth + " health remaining");
            Debug.Log("Squish!");
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
