using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Trash;

public class TrashGenerator : MonoBehaviour
{

    [Header("Prefab")]
    public GameObject trashPrefab;

    [Header("Bounds")]
    public float width;
    public float height;

    // Generate specified amount of random trash
    public void GenerateMultipleTrash(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GenerateTrash();
        }
    }
    
    // Generate specified amount of trash of specified trash type
    public void GenerateMultipleTrash(int amount, TrashType type)
    {
        for (int i = 0; i < amount; i++)
        {
            GenerateTrash(type);
        }
    }

    // Generate a new trash with a random trash type
    public GameObject GenerateTrash()
    {
        // Randomly choose trash type
        TrashType type = (TrashType)Random.Range(0, 3);

        return GenerateTrash(type);
    }

    // Generate a new trash with a specified trash type
    public GameObject GenerateTrash(TrashType type)
    {
        // Generate the random X and Y values for where the trash will spawn
        float x = Random.Range(-(width / 2), width / 2);
        float y = Random.Range(-(height / 2), height / 2);

        // Combine the X and Y values with the current position of the generator
        Vector2 spawnPos = new Vector2(transform.position.x + x, transform.position.y + y);

        // Create the newTrash object as GameObject and give it an appropriate name
        GameObject newTrash = Instantiate(trashPrefab, spawnPos, Quaternion.identity);
        newTrash.name = type.ToString() + " Trash";

        // Assign trash type to object
        newTrash.GetComponent<Trash>().type = type;

        // Put the new trash object into the TrashList array
        FindObjectOfType<GameManager>().trashCount++;

        // Return the new trash object
        return newTrash;
    }

    // Draw the bounds of the generator when selected
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(this.transform.position, new Vector2(width, height));
    }

}
