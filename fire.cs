using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject fireObject;

    public void Burn(Vector3 pos)
    {
        if(transform.childCount>0)
        {
            for(int i = 0; i< transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        pos.y -= 5;
        Instantiate(fireObject, pos, Quaternion.identity);
    }
}
