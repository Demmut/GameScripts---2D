using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadButton : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(1);
        }
    }
}
