using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    public float healValue = 20f;
    GameObject pickup;
    AudioSource pickupSound;
    GameObject player;
    Healthbar healthbar;

    private void Start()
    {
        pickup = GameObject.FindGameObjectWithTag("Pickup");
        pickupSound = pickup.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        healthbar = player.GetComponent<Healthbar>();
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            healthbar.Heal(healValue);
            pickupSound.Play();
            Destroy(this.gameObject);
        }
    }
}
