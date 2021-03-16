using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_Text))]

public class Testing : MonoBehaviour
{

    public string displayText;
    [SerializeField] public Transform pfDamagePopup;
    [SerializeField] TMP_Text popupText;
    void Start()
    {
    //  FindObjectOfType<DamagePopup>().Create(Vector3.zero, 300);




        
    }

     void Update()
    {
       // TMP_Text tmp_text = GetComponent<TMP_Text>();
       // tmp_text.text = displayText;
        //tmp_text.DOFade(0f, 0.7f);
        //displayText.CrossFadeAlpha(0.0f, 0.05f, false);
        //StartCoroutine(FadeTextToFullAlpha(1f, popupText));
        // transform.DOMove(transform.position + Vector3.up, 0.75f).OnComplete(() => 
      //  transform.position = new Vector3 (0.0f, 0.75f);


      //  Destroy(gameObject);




        }

        // public IEnumerator FadeTextToFullAlpha(float t, TMP_Text i)
        //{
        //    i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        //    while (i.color.a < 1.0f)
        //    {
        //        i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
        //        yield return null;
        //    }
        //}








    }
