using UnityEngine;

[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactor;
    Transform player;
    Vector3 newPos;
    SpriteRenderer sprt;
    fire fireScript = null;
    float width;
    public bool Wrapping = true;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        sprt = GetComponent<SpriteRenderer>();
        fireScript = GetComponent<fire>();
        width = sprt.bounds.size.x;
        newPos = transform.position;
    }

    public void Move(float delta)
    {

        if(Wrapping)
        {
            if (player.position.x - transform.position.x > width)
            {
                newPos.x = player.position.x + width / 2;
                if (fireScript != null && (Random.value > 0.2))
                {
                    fireScript.Burn(newPos);
                }
            }
            else if (player.position.x - transform.position.x < -1 * width)
            {
                newPos.x = player.position.x - width / 2;
                if (fireScript != null && (Random.value > 0.2))
                {
                    fireScript.Burn(newPos);
                }
            }
            else
            {
                newPos.x -= delta * parallaxFactor;
            }
        }
        else
        {
            newPos.x -= delta * parallaxFactor;
        }
        transform.position = newPos;
    }
}
