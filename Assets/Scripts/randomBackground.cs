using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomBackground : MonoBehaviour
{
    /**
     * Code has been used from https://www.codegrepper.com/code-examples/csharp/unity+generate+random+color/ 
     */
    // Reference to the main camera
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        // finds the camerae component in the gameObject
        cam = GetComponent<Camera>();
        // Randomly generates a random colour
        Color32 background = new Color32(
            (byte)Random.Range(0, 255),
            (byte)Random.Range(0, 255),
            (byte)Random.Range(0, 255),
            255
        );
        // sets Camerae background colour to the randomly generated colour
        cam.backgroundColor = background;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
