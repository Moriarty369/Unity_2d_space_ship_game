using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isTripleShot = false;
    public bool isSpeedUp = false;
    public bool isShieldOn = false;
    public bool isPlayerOne = false;
    public bool isPlayerTwo = false;
    

    public int lives = 3;
    //se crea un objeto "laserPrefab" que hereda de GameObject 
    //>---OJO---> hay que encontrar el fallo al pasar a private
    //(puede que sea por falta del serialized¿?)
    public GameObject laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _playerExplosionPrefab;
    [SerializeField]
    private GameObject _shieldGameObject;
    //Creamos las variables para el "cooldown system" del laser con un fireRate de 0,25f
    [SerializeField]
    private float _fireRate = 0.25f;
    [SerializeField]
    private float speed = 5.0f;
    private float _canFire = 0.0f;
    private UIManager _uiManager;
    private GameManager _gameManager;
    [SerializeField]
    private SpawnManager _spawnManager;
    private AudioSource _audioSource;
    // Creamos un arreglo para la falla de motores
    [SerializeField]
    private GameObject[] _engines;
    private int hitsCount = 0;
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;

    
    private void Start()
    {   
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager != null)
        {
            _uiManager.UpdateLives(lives);
        }

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        //no se utiliza GameObject.Find porque el audio source es el unico componente del objeto ¿¿??
        _audioSource = GetComponent<AudioSource>();
        hitsCount = 0;
       
        // Asignando posiciones iniciales a el-los player(s)
       if (_gameManager.isCoopMode == false)
       {
            transform.position = new Vector3(0, -4.2f, 0);
       }


    } 
       

    private void Update()
    {
        if (isPlayerOne == true)
        {
            PlayerOneMovement();
             // Creando laser cuando se pulsa el espacio 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShootPlayerOne();
            }
        }
        if (isPlayerTwo == true)
        {
            PlayerTwoMovement();
             // Creando laser cuando se pulsa el espacio 
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ShootPlayerTwo();
            }
        }
    } 

    private void ShootPlayerOne()
    {
        if(Time.time > _canFire)
        {   _audioSource.Play();
            if (isTripleShot == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);  
            }
            else 
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity); 
           
            
            }
            _canFire = Time.time + _fireRate;  
        }
    }

    private void ShootPlayerTwo()
    {
        if(Time.time > _canFire)
        {   _audioSource.Play();
            if (isTripleShot == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);  
            }
            else 
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity); 
           
            
            }
            _canFire = Time.time + _fireRate;  
        }
    }

    private void PlayerOneMovement()
    {
        float horizontalInput1 = Input.GetAxis("Horizontal");
        float verticalInput1 = Input.GetAxis("Vertical");
        // Creando la  (funcion de input) y posteriormente les asigno una velocidad
        // (condicionando con el speedBoost)
        if (isSpeedUp == true)
        {
            player1.transform.Translate(Vector3.right  * speed * 2.0f * horizontalInput1 * Time.deltaTime);
            player1.transform.Translate(Vector3.up * speed * 2.0f * verticalInput1 * Time.deltaTime);
        }
        else
        {
            player1.transform.Translate(Vector3.right  * speed * horizontalInput1 * Time.deltaTime);
            player1.transform.Translate(Vector3.up * speed * verticalInput1 * Time.deltaTime);
        }
           
        // Delimito el movimiento de la nave en el eje Y en el centro de la pantalla
        if (player1.transform.position.y > 0)
        {
            player1.transform.position = new Vector3(transform.position.x, 0, 0);
        }
            //Delimito ahora el eje Y en la zona baja
        else if (player1.transform.position.y < -4.2f)
        {
            player1.transform.position = new Vector3(transform.position.x,-4.2f, 0);
        }
            // Delimito el movimiento de la nave en el eje X/derecho (haciendo cambio de lado)
        if (player1.transform.position.x > 9.49f)
        {
            player1.transform.position = new Vector3(-8.18f, transform.position.y, 0);
        }
            // Delimito el movimiento de la nave en el eje vertical/izquierdo (haciendo cambio de lado)
        else if (player1.transform.position.x < -9.49f)
        {
            player1.transform.position = new Vector3(8.18f,transform.position.y, 0);
        }
    }

    private void PlayerTwoMovement()
    {
        if (isSpeedUp == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                player2.transform.Translate(Vector3.up * speed * 1.5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                player2.transform.Translate(Vector3.right * speed * 1.5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                player2.transform.Translate(Vector3.down * speed * 1.5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                player2.transform.Translate(Vector3.left * speed * 1.5f * Time.deltaTime);
            }   
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                player2.transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                player2.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                player2.transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                player2.transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
           
        // Delimito el movimiento de la nave en el eje horizontal en el centro
        if (player2.transform.position.y > 0)
        {
            player2.transform.position = new Vector3(transform.position.x, 0, 0);
        }
            //Delimito ahora el eje horizontal en la zona baja
        else if (player2.transform.position.y < -4.2f)
        {
            player2.transform.position = new Vector3(transform.position.x,-4.2f, 0);
        }
            // Delimito el movimiento de la nave en el eje vertical/derecho (haciendo cambio de lado)
        if (player2.transform.position.x > 9.49f)
        {
            player2.transform.position = new Vector3(-8.18f, transform.position.y, 0);
        }
            // Delimito el movimiento de la nave en el eje vertical/izquierdo (haciendo cambio de lado)
        else if (player2.transform.position.x < -9.49f)
        {
            player2.transform.position = new Vector3(8.18f,transform.position.y, 0);
        }
    }

    public void Damage()
    {
        if (isShieldOn == true)
        {   
            isShieldOn = false;
            _shieldGameObject.SetActive(false);
            return;
        }
        
        hitsCount ++;
        
        if (hitsCount == 1)
        {
            _engines[0].SetActive(true);
        }
        else if (hitsCount == 2)
        {
            _engines[1].SetActive(true);
        }

        lives--;
        _uiManager.UpdateLives(lives);
        if (lives < 1)
        {
            _uiManager.ShowTitleScreen();
            Instantiate(_playerExplosionPrefab, transform.position, Quaternion.identity);
            _gameManager.gameOver = true;
            Destroy(this.gameObject);
           

        }
    }

    public void TripleShotOn()
    {
        isTripleShot = true;
        //llamamos la función para apagar el tripleShot
        StartCoroutine(TripleShotDownRoutine());
    }

    public void SpeedBoostOn()
    {
        isSpeedUp = true;
        StartCoroutine(SpeedBoostDownRoutine());
    }

    public void ShieldBoostOn()
    {
        isShieldOn = true;
        _shieldGameObject.SetActive(true);
        StartCoroutine(ShieldDownRoutine());
    }

    public IEnumerator TripleShotDownRoutine()
    {
        yield return new WaitForSeconds (5.0f);
        isTripleShot = false;
    }

    public IEnumerator SpeedBoostDownRoutine()
    {
        yield return new WaitForSeconds (5.0f);
        isSpeedUp = false;
    }
    public IEnumerator ShieldDownRoutine()
    {
        yield return new WaitForSeconds (5.0f);
        isShieldOn = false;
        _shieldGameObject.SetActive(false);
    }
}

                                                                                                                                                            
    

