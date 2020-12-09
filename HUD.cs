using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Player player;
    public Text jumpScoreText;

    public Slider healthBar;
    public Slider energyBar;
    public Image energyBarColour;

    public Text minutesText;
    public Text secondsText;

    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpScoreText.text = player.jumpEnergy.ToString();
        healthBar.value = player.health / 100.0f;
        energyBar.value = player.energy;
        if (player.isTired)
        {
            energyBarColour.color = new Color(1.0f, 0.0f, 1.0f);
        }
        else
        {
            energyBarColour.color = new Color(1.0f, 1.0f, 0.0f);
        }

        float t = timer.GetTimeRemaining();
        minutesText.text =  Mathf.FloorToInt(t / 60.0f).ToString();
        secondsText.text = (t % 60).ToString();
    }
}
