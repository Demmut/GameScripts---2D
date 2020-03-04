using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InsideOf : MonoBehaviour
{
    protected List<GameObject> insideMe = new List<GameObject>();
    public Subtitles subtitles;

    List<string> Lines = new List<string>();

    private void Start()
    {
        Lines.Add("Hey, my name is ");
        Lines.Add("I am called ");
        Lines.Add("You can call me ");
        Lines.Add("You are in the presence of ");
        Lines.Add("It's called ");
    }

    void Speak(Collider2D e)
    {
        if(e.tag == "NPC")
        {
            subtitles.Write(Lines[Random.Range(0, Lines.Count - 1)] + e.name.Replace("(Clone)",""));
        }
    }

    public void Follow(Collider2D e)
    {
        if(e.tag == "NPC")
        {
            e.gameObject.GetComponent<BasicAI>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D e)
    {
        if (e.gameObject != null)
         {
            if (!this.insideMe.Contains(e.gameObject))
            {
                Follow(e);
                Speak(e);
                this.insideMe.Add(e.gameObject);
            }
        }
    }
}