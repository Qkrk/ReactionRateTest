using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ButtonController : MonoBehaviour
{
    public TMP_Text buttonText;
    public TMP_Text text;
    public TMP_Text BeforeText;
    private float Starttime;
    private float Averagerate = 0;
    private float ReactionTime = 0;
    private int Count = 0;

    void Start()
    {
        StartCoroutine(RandomRoutine());
        buttonText.text = "Wait a moment...";
        Camera.main.backgroundColor = new Color(.7f, .1f, .2f);
        text.text = $"your reaction Delay:{Averagerate: 0.0}ms";
        BeforeText.text = $"Before Reaction Delay : {ReactionTime : 0.0}ms";
    }

    public void OnClick()
    {
        if (buttonText.text == "Wait a moment...")
            return;
        buttonText.text = "Wait a moment...";
        ReactionTime = (Time.time - Starttime) * 1000;
        Camera.main.backgroundColor = new Color(.7f, .1f, .2f);
        Averagerate = (((Averagerate * Count) + ReactionTime) / ++Count);
        text.text = $"your reaction Delay:{Averagerate: 0.0}ms";
        BeforeText.text = $"Before Reaction Delay : {ReactionTime: 0.0}ms";
    }

    private IEnumerator RandomRoutine()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            if (buttonText.text == "Wait a moment...")
            {
                Starttime = Time.time;
                buttonText.text = "Click!!";
                Camera.main.backgroundColor = new Color(0f, .7f, .3f);
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(3f, 5f));
            }
        }
    }
}
