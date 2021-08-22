using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Player _player;
    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
             _player.AddToScore(1);    
            Destroy(this.gameObject);
        }
    }
}
