using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float maxDist;
    public float currentPos;
    public Direction dir;
    [Range(1, 2)]
    public float speed;

    public enum Direction
    {
        left,
        right
    }

    private void Start()
    {

        currentPos = transform.position.x;

        if(currentPos < 0)
        {
            dir = Direction.right;
        }
        else
        {
            dir = Direction.left;
        }

        if(speed == 0)
        {
            speed = Random.Range(1f, 2f);
        }
    }

    // Update is called once per frame
    void Update()
    {

        currentPos = transform.position.x;

        if (currentPos < -maxDist)
        {
            dir = Direction.right;
            speed = Random.Range(1f, 2f);
            transform.position = new Vector2(transform.position.x, Random.Range(-1f, 4f));
        }
        else if(currentPos > maxDist)
        {
            dir = Direction.left;
            speed = Random.Range(1f, 2f);
            transform.position = new Vector2(transform.position.x, Random.Range(-1f, 4f));
        }

        if (dir == Direction.left)
        {
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            
        }
        else
        {
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        }

        
    }
}
