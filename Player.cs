using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson; //inlcude this to acess variables on the playercontroller classes
using UnityEngine;


public class Player : MonoBehaviour
{
    public int jumpEnergy = 0;
    bool hasKey = false;
    public float health = 100.0f;
    Vector3 respawnPos;

    //Energy
    public float energy = 1.0f;
    public bool isTired = false;

    public List<InventoryItem> Inventory = new List<InventoryItem>();



    public List<Sprite> mySprites = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        respawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckSetJumpForce();
        }

        CheckSetEnergy();
    }

    private void CheckSetEnergy()
    {
        //whilst key is pressed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(energy > 0.0f && !isTired)
            {
              energy -= (Time.deltaTime / 3.0f);
            }
            if (energy <= 0.0f)
            {
                isTired = true;
                GetComponent<RigidbodyFirstPersonController>().movementSettings.RunMultiplier = 1.0f;
            }
        }

        //whilst key is not pressed
        else if (energy < 1.0f)
        {
            energy += (Time.deltaTime / 5.0f);
        }
        else if (isTired)
        {
            GetComponent<RigidbodyFirstPersonController>().movementSettings.RunMultiplier = 2.0f;
            isTired = false;
            energy = 1.0f;
        }
        //Debug.Log(energy);
    }

    private void CheckSetJumpForce()
    {
        float targetJumpForce;
        if (jumpEnergy > 0)
        {
            targetJumpForce = 100.0f;
        }
        else
        {
            targetJumpForce = 50.0f;
        }
        GetComponent<RigidbodyFirstPersonController>().movementSettings.JumpForce = targetJumpForce;
        Debug.Log("Jump force is: " + targetJumpForce);

        if(jumpEnergy > 0)
        {
            jumpEnergy--;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Key":
                Debug.Log("I have collected the key");
                Destroy(collision.gameObject);
                hasKey = true;
                break;
            case "Door":
                Debug.Log("I have hit the door");
                if (hasKey)
                {
                    Destroy(collision.gameObject);
                }
                break;
            default:
                break;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Health is: " + health);
        if(health <= 0.0f)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.SetPositionAndRotation(respawnPos, Quaternion.identity);
        health = 100.0f;
    }
}
