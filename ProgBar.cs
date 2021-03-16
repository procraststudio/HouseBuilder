using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode()]
public class ProgBar : MonoBehaviour
{

    public int minimum;
    public int maximum;
    public int current;
    public Image mask;
    public Image fill;
    public Color color;

    public bool materialsBar;
    public bool moneyBar;





    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }


    void GetCurrentFill()

    {
        if (materialsBar)
        {
            current = FindObjectOfType<Game>().GetMaterials();
        }
        else if (moneyBar)
        {
            current = FindObjectOfType<Game>().GetMoney();
        }

        //float fillAmount = (float)current / (float)maximum;

        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;

        mask.fillAmount = fillAmount;
        fill.color = color;
    }



}
