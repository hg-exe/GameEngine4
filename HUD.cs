using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    // Tutorial Text
    private Text tutorialText;
    float timeToDisplay = 3.0f;
    bool isCountingDown = false;


    //Stamina
    public Slider staminaBar;
    public Player player;


    // Start is called before the first frame update
    void Start()
    {
        tutorialText = GameObject.Find("TutorialText").GetComponent<Text>();

    }

    void Update()
    {
        if (isCountingDown)
        {
            timeToDisplay -= Time.deltaTime;
            if (timeToDisplay <= 0)
            {
                isCountingDown = false;
                tutorialText.text = "";
            }
        }


        //Stamina Bar
        staminaBar.value = player.stamina;
    }

    public void SetTutorialText(string textToDisplay)
    {
        tutorialText.text = textToDisplay;
        timeToDisplay = 3.0f;
        isCountingDown = true;
    }
}
