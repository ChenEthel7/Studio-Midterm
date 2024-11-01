using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourchange : MonoBehaviour
{
    public Color newColor = Color.red;  // Choose the desired color in the Inspector

    void Start()
    {
        // Get the MeshRenderer component attached to the object
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        // Change the color of the material (without creating a new material)
        meshRenderer.material.color = newColor;
    }
}
