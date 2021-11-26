using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float stamina = 1.0f;
    bool isSprinting = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("I have Pressed Shift");
            isSprinting = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("I have Released Shift");
            isSprinting = false;
        }

        if (isSprinting)
        {
            stamina -= Time.deltaTime;

            if (stamina < 0.0f)
            {
                stamina = 0.0f;
            }
        }
        else
        {
            stamina += Time.deltaTime;
            if (stamina > 1.0f)
            {
                stamina = 1.0f;
            }
        }
        Debug.Log(stamina);
    }
}
