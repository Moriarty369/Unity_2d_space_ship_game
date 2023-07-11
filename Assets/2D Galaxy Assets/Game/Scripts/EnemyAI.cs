using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float _enemySpeed = 1.0f;
    private UIManager _uiManager;
    [SerializeField]
    private GameObject _enemyExplosionPrefab;
    [SerializeField]
    private AudioClip _audioClip;

    private void Start()
    {
    //heredamos del ui manager del canvas para usar la funcion UpdateScore posteriormente
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);//velocidad enemigo
    //delimito eje inferior/horizontal del enemigo para que reaparezca arriba con eje x random
        if (transform.position.y < -4.2f)
        {   
            float randomX = Random.Range(-8, 8);
            transform.position = new Vector3(randomX, 6.6f, 0);
            //restar puntos al player
            // modificamos el score antes de destruir nuestro objeto (self)
            _uiManager.SubstractScore();
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
    //analizando si la colision es con el player o con el laser
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
                Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
                //OJO debo conseguir que el shield bloquee esta funcion
                _uiManager.SubstractScore();
                AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position);
                Destroy(this.gameObject);

            }
        }
        else if (other.tag == "Laser")
        {
            if (other.transform.parent != null)//Destruir padre de laser triple
            {
                Destroy(other.transform.parent.gameObject);
            }
            LaserBehaviour laser = other.GetComponent<LaserBehaviour>();
            if (laser != null)
            {
                Destroy(this.gameObject);
                Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                // modificamos el score antes de destruir nuestro objeto (self)
                _uiManager.UpdateScore();
                AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position);
                Destroy(this.gameObject);
            }
        }  
    }
}


    

