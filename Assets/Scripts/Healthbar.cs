using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] Image healthbar;

    public float hitpoints = 100;
    public float maxHitpoints = 100;
    public bool dead;

    private void Start()
    {
        UpdateHealthbar();
    }

    private void FixedUpdate()
    {
        UpdateHealthbar();
        if (hitpoints <= 0)
        {
            dead = true;
        }
    }

    private void UpdateHealthbar()
    {
        float ratio = hitpoints / maxHitpoints;
        healthbar.rectTransform.localScale = new Vector2(ratio, 1);
    }

    public void TakeDamage(float damage)
    {
        hitpoints -= damage;
        UpdateHealthbar();
    }

    public void Heal(float heal)
    {
        hitpoints += heal;
        if (hitpoints > maxHitpoints)
            hitpoints = maxHitpoints;
        UpdateHealthbar();
    }
}
