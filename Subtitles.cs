using UnityEngine.UI;
using UnityEngine;

public class Subtitles : MonoBehaviour
{
    Text text;
    float timer = 0;
    void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        if(Time.time > timer)   
        {
            text.text = "";
            text.color = Color.white;
        }
    }

    public void Write(string strToWrite)
    {
        text.color = Color.white;
        timer = Time.time + 5f;
        text.text = strToWrite;
    }
    public void Write(string strToWrite, Color color)
    {
        timer = Time.time + 5f;
        text.text = strToWrite;
        text.color = color;
    }
}
