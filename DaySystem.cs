using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaySystem : MonoBehaviour
{

    public int hour;
    //public int numOfHearts;

    public Image[] clocks;

    public Sprite clockImage;
    public Sprite nightImage;

    private void Update()
    {
        hour = FindObjectOfType<Game>().GetHour();

        //clocks[i].enabled = true;
        //   clockImage = clocks[hour-1];

        //  if (health > numOfHearts)
        // {
        //   health = numOfHearts;

        // }



        for (int i = 0; i < clocks.Length; i++)
        {
            if (i < hour)
            {
                clocks[i].sprite = clockImage;
            }
            else
            {
                clocks[i].sprite = nightImage;
            }

            //if (i < numOfHearts)
            //{
            //    hearts[i].enabled = true;
            //}
            //else
            //{
            //    hearts[i].enabled = false;
            //}
        }

    }
}

