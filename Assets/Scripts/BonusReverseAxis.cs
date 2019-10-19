using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusReverseAxis : MonoBehaviour
{
    public GameObject AxisReversedText;
    
    void OnCollisionEnter(Collision other)
    {
        //Get all the paddles in the game
        GameObject[] paddleGameObjects = GameObject.FindGameObjectsWithTag("Paddle");

        if (AxisReversedText.activeSelf) {
            AxisReversedText.SetActive(false);

            //re-invert the axis for the paddles.
            for (int i = 0; i < paddleGameObjects.Length; i++) {
            paddleGameObjects[i].GetComponent<PaddleMovement>().isAxisReversed = false;  
            transform.localScale -= new Vector3(0,0,3);  
            }
        } 
        else 
        {   //Invert the axis for the paddles.
             AxisReversedText.SetActive(true);
             for (int i = 0; i < paddleGameObjects.Length; i++) {
            paddleGameObjects[i].GetComponent<PaddleMovement>().isAxisReversed = true;
            transform.localScale += new Vector3(0,0,3);   
            }
        }
        
    }
}

