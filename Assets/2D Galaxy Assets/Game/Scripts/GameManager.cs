using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
//referenciamos al script player
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _coopPlayers;
    // Creamos una variable para distinguir entre escenas (single and two players)
    public bool isCoopMode = false;
    public bool gameOver = true;
    private UIManager _uiManager;
    private SpawnManager _spawnManager;
    

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    
    }


    void Update()
    {
        if (gameOver == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (isCoopMode == false)
                {
                    Instantiate(_player, Vector3.zero, Quaternion.identity);
                }
                else
                {
                    Instantiate(_coopPlayers, Vector3.zero, Quaternion.identity);
                }
                
                gameOver = false;
                _uiManager.HideTitleScreen();
                _spawnManager.StartSpawnRoutines();

            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
