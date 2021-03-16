using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//public class Choices : MonoBehaviour
//{

//    public GameObject TextBox;
//    public GameObject Choice01;
//    public GameObject Choice02;
//    public GameObject EventPanel;
//    public GameObject finalText;
//    public int Choicemade;

//    public int d100;

//    public GameObject continueButton;
//    public GameObject startText;



//    void Start()
//    {
//      //  Choicemade = 0;
//    }

//    public void ChoiceOption1() {

//        d100 = Random.Range(1, 101);
//        Debug.Log("Number was " + d100);


//        if (d100 <= 70)
//        {
//            finalText.GetComponent<TextMeshProUGUI>().text = "That's good. You've made the first choice. +3 Wood";
//            FindObjectOfType<Game>().WoodChange(3);
//        }
//        else
//        {
//            finalText.GetComponent<TextMeshProUGUI>().text = "That's pretty good. +1 Wood";
//            FindObjectOfType<Game>().WoodChange(1);
//        }
//        Choicemade = 1;
//        EventResult();
//    }

//    public void ChoiceOption2()
//    {
//        d100 = Random.Range(1, 101);
//        Debug.Log("Number was " + d100);

//        if (d100 <= 70)
//        {
//            finalText.GetComponent<TextMeshProUGUI>().text = "That's different. You've made the second choice. -1 Wood";
//            FindObjectOfType<Game>().WoodChange(-1);
//        }

//        else
//        {
//            finalText.GetComponent<TextMeshProUGUI>().text = "That's terrible. -3 Wood";
//            FindObjectOfType<Game>().WoodChange(-3);

//        }
//        Choicemade = 2;
//        EventResult();
//    }


//    public void EventResult()
//    {
        
//        Choice01.SetActive(false);
//        Choice02.SetActive(false);
//        startText.SetActive(false);
//        continueButton.SetActive(true);
//        Choicemade = 0; 
       
//    }

//    public int GetChoicemade()
//    {
//        return Choicemade;
//    }


   // void Update()
   // {
    //    if (Choicemade >=1)
    //    {
    //        Choice01.SetActive(false);
    //        Choice02.SetActive(false);
    //        continueButton.SetActive(true);
    //        Choicemade = 0;
    //    }
 //   }
//}
