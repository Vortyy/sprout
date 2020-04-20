using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] Healthbar healthbar;
    private TextMeshProUGUI textmesh;
    public int score;
    private int min;
    private int sec;

    private void Start()
    {
        textmesh = GetComponent<TextMeshProUGUI>();
        score = min = sec = 0;
        StartCoroutine(Counter());
    }

    public void UpdateTime()
    {
        min = score / 60;
        sec = score % 60;
        textmesh.text = min.ToString() + "m " + sec.ToString() + "s";
    }

    IEnumerator Counter()
    {
        while (!healthbar.dead)
        {
            yield return new WaitForSecondsRealtime(1);
            score++;
            UpdateTime();
        }
    }
}
