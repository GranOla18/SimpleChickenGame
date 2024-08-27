using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_HUD : MonoBehaviour
{
    public Image healthBar;
    public Gradient gradient;
    //public Gradient gradient2;
    public ChickenManager chicken;
    public Text healthVal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = chicken.health / 100f;
        //Evaluate va de 0 - 1
        healthBar.color = gradient.Evaluate(healthBar.fillAmount);
        healthVal.text = chicken.health.ToString();

        //gradient2.colorKeys[0].color = Color.green;
        //gradient2.colorKeys[1].color = Color.red;

        //gradient2.colorKeys[0].time = 0f;
        //gradient2.colorKeys[1].time = 1f;

        //gradient2.Evaluate(healthBar.fillAmount);

    }
}
