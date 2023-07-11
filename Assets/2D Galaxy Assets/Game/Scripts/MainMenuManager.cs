using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
   public void LoadSinglePlayerGame()
   {
        SceneManager.LoadScene("SinglePlayer");
   }

   public void LoadTwoPlayersGame()
   {
        SceneManager.LoadScene("CooperativeMode");
   }
}
