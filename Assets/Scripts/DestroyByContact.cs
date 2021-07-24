using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    private GameController gameController;
    public GameObject explosion;
    public GameObject shipExplosion;
    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "boundary")
        {
            return; //alt satırları okumaz.
        }
        Instantiate(explosion, this.transform.position, this.transform.rotation);
        if(other.tag == "ship")
        {
            Instantiate(shipExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.UpdateScore();
    }
}
