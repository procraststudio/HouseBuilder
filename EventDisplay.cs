using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventDisplay : MonoBehaviour
{
    public Event currentEvent;

    public TextMeshProUGUI ID;
    public TextMeshProUGUI strength;
    public Text attack;
    public Text defense;
    public Text PP;
    public Text PK;
    public Text OT;
    public Text PEN;
    // public GameObject[] stars;
    // public int starNumber;

    public Image logoImage;
    // public int teamPower;



    void Start()
    {

        //ID.text = currentEvent.
        //strength.text = team.strength.ToString();
        //attack.text = team.attackLevel.ToString();
        //defense.text = team.defenseLevel.ToString();
        //PP.text = team.powerPlay.ToString();
        //PK.text = team.penaltyKill.ToString();
        //logoImage.sprite = team.image;




    }

    void Update()
    {
        // teamPower = home.ToString();
        // DisplayStars();
    }

    public void DisplayStats()
    {
        //ID.text = team.teamName;
        //strength.text = team.strength.ToString();
        //attack.text = team.attackLevel.ToString();
        //defense.text = team.defenseLevel.ToString();
        //PP.text = team.powerPlay.ToString();
        //PK.text = team.penaltyKill.ToString();
        //logoImage.sprite = team.image;

        //OT.text = team.overtimeStrenght.ToString();
        //PEN.text = team.penaltiesStrenght.ToString();

    }
}
