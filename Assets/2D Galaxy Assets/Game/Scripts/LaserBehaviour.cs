using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    public float laserSpeed = 10.0f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);

    // if para destruir el laser al salir de la pantalla
        if (transform.position.y >= 6 )
        {
            if (transform.parent != null) //analizamos si hay elementos padres que destruir en el caso del triple laser
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
