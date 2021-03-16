using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DamagePopup : MonoBehaviour
{
    [SerializeField] public Transform pfDamagePopup;
    

    public DamagePopup Create(Vector3 position, int damageAmount)
    {
       // position = new Vector3(18f, 528f);
        Transform damagePopupTransform = Instantiate(pfDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount);

        return damagePopup;
    }
    
    private TextMeshPro textMesh;


    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();

    }


    public void Setup(int damageAmount)
    { 
        textMesh.SetText(damageAmount.ToString());
    }

 
}
