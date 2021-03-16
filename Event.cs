using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Event", menuName = "Event")]


public class Team : ScriptableObject
{
    public string eventName;
    public Sprite image;

    [TextArea()] public string startText;
    [TextArea()] public string option1;
    [TextArea()] public string option2;
    [TextArea()] public string finalText;



    public Team(string ID, Sprite logo, string startOpt, string firstOpt, string secondOpt, string finalOpt)
    {
        this.eventName = ID;
        this.image = logo;
        this.startText = startOpt;
        this.option1 = firstOpt;
        this.option2 = secondOpt;
        this.finalText = finalOpt;      
    }
}
