using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public Vector3 targetPosition;
    private Vector3 correctPosition;
    private SpriteRenderer sprite;
    private int targetCount = 0;
    private bool checkActiveButton = true;
    void Awake()
    {
        targetPosition = transform.position;
        correctPosition = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition,0.05f);

       
            if (targetPosition == correctPosition)
            {
                sprite.color = Color.green;
                targetCount++;
            }
            else
            {
                sprite.color = Color.red;
                targetCount--;
            }

            if (checkActiveButton)
            {
                  Invoke("activateButton",3.0f);
            }

         Debug.Log(targetCount.ToString());
            
    }

    public void activateButton()
    {
         if (targetCount==8)
         {
             checkActiveButton = false;
             Debug.Log("aktifleşti");
         }
                    
    }

   
}
