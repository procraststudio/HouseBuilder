using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
   
    private Transform clockHandTransform;


    private void Awake()
    {
        clockHandTransform = transform.Find("clockHand");
    }


    private void Update()
    {
        clockHandTransform.eulerAngles = new Vector3(0, 0, -Time.realtimeSinceStartup * 30f);
    }

}
