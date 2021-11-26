using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTrigger : MonoBehaviour
{

    [SerializeField] string messageToDisplay;
    public HUD HeadsUpDisplay;


    void Start()
    {
        HeadsUpDisplay = GameObject.FindObjectOfType<HUD>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            HeadsUpDisplay.SetTutorialText(messageToDisplay);
        }
    }
}
