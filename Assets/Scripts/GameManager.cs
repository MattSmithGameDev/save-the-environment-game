using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Bin Settings")]
    [Tooltip("The minimum distance all bins must be from the sides of the screen")]
    public float minDist = 2;

    [Header("Score")]
    public int correct = 0;
    public int incorrect = 0;

    [Header("Trash Counter")]
    public int trashCount;

    private TMP_Text correctText;
    private TMP_Text incorrectText;

    [Header("Game UI Elements")]
    public GameObject winPanel;
    public GameObject raycastBlocker;

    private Animator correctAnimator;
    private Animator incorrectAnimator;

    private TrashGenerator TG;

    public void Start()
    {
        // Find the score texts
        correctText = GameObject.Find("CorrectScore").GetComponent<TMP_Text>();
        incorrectText = GameObject.Find("IncorrectScore").GetComponent<TMP_Text>();

        // Find the animators for the score texts
        correctAnimator = correctText.GetComponent<Animator>();
        incorrectAnimator = incorrectText.GetComponent<Animator>();

        // Clamp each bin
        foreach(TrashBin bin in FindObjectsOfType<TrashBin>())
        {
            ClampBin(bin.gameObject);
        }

        // Get this GameObject's TrashGenerator and generate 10 trash
        TG = GetComponent<TrashGenerator>();
        TG.GenerateMultipleTrash(10);
    }

    // Add val to correct and return the value
    public int AddCorrect(int val)
    {
        correct += val;
        correctAnimator.Play("ScoreIncrement");
        correctText.text = correct.ToString();
        return correct;
    }

    // Add val to incorrect and return the value
    public int AddIncorrect(int val)
    {
        incorrect += val;
        incorrectAnimator.Play("ScoreIncrement");
        incorrectText.text = incorrect.ToString();
        return incorrect;
    }

    // Check if the list is empty, and perform an action if it is
    public void CheckCount()
    {
        if(trashCount <= 0)
        {
            ShowWinPanel();
        }
    }

    private void ShowWinPanel()
    {
        // Activate the win panel and it's raycast blocker 
        winPanel.SetActive(true);
        raycastBlocker.SetActive(true);

        // Update the scores on the panle
        GameObject.Find("FinalCorrect").GetComponent<TMP_Text>().text = "Correct\n" + correct;
        GameObject.Find("FinalIncorrect").GetComponent<TMP_Text>().text = "Incorrect\n" + incorrect;
    }

    private void ClampBin(GameObject bin)
    {
        // Find the left and right bounds of the screen
        float leftBound = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        float rightBound = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;

        // Clamp the bin to the within the bounds + the min dist
        float newX = Mathf.Clamp(bin.transform.position.x, leftBound + minDist, rightBound - minDist);

        // Update bin position
        bin.transform.position = new Vector2(newX, -3.5f);
    }
}
