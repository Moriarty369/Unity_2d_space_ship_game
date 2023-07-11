using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{   
    [SerializeField]
    private float _powerUpSpeeds = 3.0f;
    public int powerUpID; //tripleShot = 0, speedBoost = 1, shields = 2
    [SerializeField]
    private AudioClip _audioPowerUps;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.down * _powerUpSpeeds * Time.deltaTime);  
          //delimito eje inferior/horizontal 
        if (transform.position.y < -4.2f)
        {   
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //analizando si la colision es con el jugador, accedemos al player y a su booleano canTripleShoot para triggear a true el tripleShot
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
            //llamando diferentes powerUps
                if (powerUpID == 0)
                {
                    player.TripleShotOn();
                }
                else if (powerUpID == 1) 
                {
                    player.SpeedBoostOn();
                }
                else if (powerUpID == 2) 
                {
                    player.ShieldBoostOn();
                }

            }
            AudioSource.PlayClipAtPoint(_audioPowerUps, Camera.main.transform.position);
            //Destruimos el objeto powerUp
            Destroy(this.gameObject);
        }   
    }
}

