using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scenario : MonoBehaviour
{
    Transform playerTransform = null;
    public GameObject RedHead;
    public GameObject Aylin;
    public GameObject Boy;
    public GameObject Skeleton;
    public GameObject Cookie;
    public GameObject Boss;
    bool BossIn = false;

    Vector3 pos;
    Subtitles text;
    int random;
    List<string> lines = new List<string>();


    List<GameObject> NPCs = new List<GameObject>();
    float timer;

    private void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        timer = Time.time + Random.Range(5, 10);
        text = GameObject.Find("Subtitles").GetComponent<Subtitles>();
        NPCs.Add(RedHead);
        NPCs.Add(Aylin);
        NPCs.Add(Boy);
        NPCs.Add(Skeleton);
        lines.Add("I hear something");
        lines.Add("Is there anybody hearing me!");
        lines.Add("Who is this?");
        lines.Add("Hey, where are you?");
        pos = playerTransform.position;
        pos.x += 1000;
        Instantiate(Cookie, pos, Quaternion.identity);
    }



    private void Update()
    {
        if(Time.time > timer)
        {
            if (Random.value > .5f)
            {
                if(NPCs.Count > 0)
                {
                    random = Random.Range(0, NPCs.Count - 1);
                    pos = playerTransform.position;
                    pos.x += 20;
                    Instantiate(NPCs[random], pos, Quaternion.identity);
                    NPCs.RemoveAt(random);
                    text.Write(lines[Random.Range(0, lines.Count-1)], Color.yellow);
                    timer += Random.Range(5, 10);
                }
            }
            if(Random.value > .5f && !BossIn)
            {
                BossIn = true;
                pos = playerTransform.position;
                pos.x -= 20;
                Instantiate(Boss, pos, Quaternion.identity);
            }
        }
    }
}
