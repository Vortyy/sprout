using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] GameObject healthbarUI;
    [SerializeField] GameObject timeCounter;
    [SerializeField] GameObject deathMenu;
    [SerializeField] GameObject player;
    Healthbar healthbar;
    [SerializeField] AudioSource soundtrack;
    [SerializeField] AudioSource deathSound;
    // [SerializeField] AudioClip death;

    private void Start()
    {
        // Grab necessary components from player GameObject
        healthbar = player.GetComponent<Healthbar>();
    }

    private void Update()
    {
        if (healthbar.dead)
        {
            // Initiate death sequence 
            soundtrack.gameObject.SetActive(false);
            deathSound.gameObject.SetActive(true);
            StartCoroutine(DeathCoroutine());
        }
    }

    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(2);
        deathMenu.SetActive(true);
        healthbarUI.SetActive(false);
        timeCounter.SetActive(false);
        player.SetActive(false);
    }
}
