using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public Sprite[] livesArray;
    public Image livesImageDisplay;
    public GameObject titleScreen;
    public TextMeshProUGUI scoreText;
    public int score;
   
    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = livesArray[currentLives];
    }

    public void UpdateScore()   
    {   // Verificamos que el player siga existiendo para que no se mueva el score una vez muerto
        if (GameObject.FindWithTag("Player") != null)
        {
        score += 10;
        scoreText.text = "Score: " + score;
        }
    }

   public void SubstractScore()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            if (score >= 20)  // Restar solo si el puntaje es mayor o igual a 20
            {
                score -= 20;
            }
            else  // Si el puntaje es menor a 20, establecerlo en 0
            {
                score = 0;
            }
            scoreText.text = "Score: " + score;
        }
    }


    public void ShowTitleScreen()
    {
        titleScreen.SetActive(true);
        scoreText.text = "Score: " + score;
        
    } 


    public void HideTitleScreen()
    {
        score = 0;
        titleScreen.SetActive(false);
        scoreText.text = "Score: ";
    }   
}
