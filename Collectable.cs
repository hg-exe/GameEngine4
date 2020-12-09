using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    bool dormant = false;
    [SerializeField] float respawnTime = 5.0f;
    private float timeDormant = 0.0f;
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.jumpEnergy++;
            Debug.Log("Jump energy is: " + player.jumpEnergy);
            SetCollectableActive(false);
        }
    }

    private void Update()
    {
        if (dormant)
        {
            timeDormant += Time.deltaTime;
            if(timeDormant >= respawnTime)
            {
                SetCollectableActive(true);
            }
        }
    }

    void SetCollectableActive(bool isActive)
    {
        GetComponent<MeshRenderer>().enabled = isActive;
        GetComponent<Collider>().enabled = isActive;
        dormant = !isActive;
        if (isActive)
        {
            timeDormant = 0.0f;
        }
    }
}
