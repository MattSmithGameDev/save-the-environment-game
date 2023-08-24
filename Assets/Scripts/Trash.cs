using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public TrashType type;
    public Sprite[] plasticSprites;
    public Sprite[] canSprites;
    public Sprite[] glassSprites;

    public enum TrashType
    {
        Plastic,
        Can,
        Glass
    }

    // Play the spawn animation on creation
    private void Start()
    {
        switch (type)
        {
            case TrashType.Plastic:
                GetComponent<SpriteRenderer>().sprite = plasticSprites[Random.Range(0, plasticSprites.Length)];
                break;
            case TrashType.Can:
                GetComponent<SpriteRenderer>().sprite = canSprites[Random.Range(0, canSprites.Length)];
                break;
            case TrashType.Glass:
                GetComponent<SpriteRenderer>().sprite = glassSprites[Random.Range(0, glassSprites.Length)];
                break;
            default:
                // Destroy the object if it is somehow an undefined type
                Destroy(this);
                break;
        }

        GetComponent<Animator>().Play("TrashSpawn");
    }

    // Move object to mouse position when left button is held
    private void OnMouseDrag()
    {
        // Get the mouse position as Vector2 in world space
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Move object to mouse pos
        transform.position = mousePos;
    }

}
