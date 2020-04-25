using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDecay : MonoBehaviour
{
    Healthbar healthbar;
    public float damagePerSecond = 1f;
    public float multiplier = 1f;
    public bool stopped;

    void Start()
    {
        healthbar = GetComponent<Healthbar>();
        StartCoroutine(DecayAcceleration());
    }

    void FixedUpdate()
    {
        if (healthbar.dead)
        {
            stopped = true;
        }

        if (!stopped)
        {
            healthbar.TakeDamage(damagePerSecond * multiplier * Time.fixedDeltaTime);
        }        
    }

    IEnumerator DecayAcceleration()
    {
        do
        {
            yield return new WaitForSeconds(30);
            multiplier+=0.5f;
        } while (!stopped);
        
    }
}
