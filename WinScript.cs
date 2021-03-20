using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    [SerializeField] GameObject winSFX;


    private float timer = 0f;
    public float maxTime = 6;
    public float height;
    public float width;
    void Start()
    {
       // Instantiate(winSFX, transform.position, Quaternion.identity);
       // Destroy(winSFX, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxTime)
        {

            spawnParticles();
            
        }



    }

    public void spawnParticles()
    {
        Instantiate(winSFX, new Vector3(Random.Range(-width, width), Random.Range(-height, height)), Quaternion.identity);
        timer = 0;
         maxTime += 10;
        Destroy(winSFX, 6f);
        

    }
}
