using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Trash;

public class TrashBin : MonoBehaviour
{
    public TrashType acceptedTrash;

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Get the trash component
        Trash trash = col.GetComponent<Trash>();

        // Only do this if the object is actually trash
        if (trash != null)
        {
            // If the trash is the correct type, increment the correct score
            // Otherwise, increment the incorrect score
            if (trash.type == acceptedTrash)
            {
                FindObjectOfType<GameManager>().AddCorrect(1);
            }
            else
            {
                FindObjectOfType<GameManager>().AddIncorrect(1);
            }

            // Delete trash object and remove from the trash list
            FindObjectOfType<GameManager>().trashCount--;
            Destroy(trash.gameObject);

            // Check the list to see if the game is completed
            FindObjectOfType<GameManager>().CheckCount();

        }
    }

}
