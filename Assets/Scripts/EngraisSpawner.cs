using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngraisSpawner : MonoBehaviour
{
    [SerializeField] GameObject engrais;
    private float engraisHeight;

    private void Start()
    {
        spawnEngrais();
    }
    private void Update()
    {
        GameObject engrais = GameObject.FindGameObjectWithTag("Healing");

        if (!engrais)
        {
            spawnEngrais();
        }
        else
        {
            engrais.transform.position = new Vector2(engrais.transform.position.x, engraisHeight + 0.2f * Mathf.Sin(3 * Time.time));
        }       
    }

    // Update is called once per frame
    void spawnEngrais()
    {
        GameObject healing = Instantiate(engrais, transform.position, Quaternion.identity);
        randomLocation(healing);
        engraisHeight = healing.transform.position.y;
    }

    void randomLocation(GameObject engrais)
    {
        float rngLocation = Random.Range(1, 9);

        switch (rngLocation)
        {
            case 1: // Floor left
                engrais.transform.position = new Vector2(-30, 4.5f);
                break;

            case 2: // Floor middle
                engrais.transform.position = new Vector2(0, 4.5f);
                break;

            case 3: // Floor right
                engrais.transform.position = new Vector2(30, 4.5f);
                break;

            case 4: // Bottom left platform
                engrais.transform.position = new Vector2(-30, 13.25f);
                break;

            case 5: // Bottom right platform
                engrais.transform.position = new Vector2(30, 13.25f);
                break;

            case 6: // Middle platform
                engrais.transform.position = new Vector2(0, 23.5f);
                break;

            case 7: // Top left platform
                engrais.transform.position = new Vector2(-30, 33.25f);
                break;

            case 8: // Top right platform
                engrais.transform.position = new Vector2(30, 33.25f);
                break;

            default: // In case it somehow fucks up, floor middle
                engrais.transform.position = new Vector2(0, 4.5f);
                break;
        }
    }
}
