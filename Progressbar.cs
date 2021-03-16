using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode()]

public class Progressbar : MonoBehaviour
{
    // Start is called before the first frame update
    //[MenuItem("GameObject/UI/Linear Progress Bar")];

    //public static void AddLinearProgressBar()
    //{
    //    GameObject obj = Instantiate(Resources.Load<GameObject>("UI/Linear Progress Bar"));
    //    obj.transform.SetParent(Selection.activeGameObject.transform, false);

    //}


    public int maximum; //(np. 250)

    public int minimum;
    public int current;
    public Image mask;

    public Image fill;
    public Color color;

    void Update()
    {

        GetCurrentFill();
    }



    void GetCurrentFill()
    {
        //float currentOffset = current - minimum;
        float currentOffset = FindObjectOfType<Game>().GetMaterials() - minimum;

        float maximumOffset = maximum - minimum;

        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;

        fill.color = color;

    }

}
