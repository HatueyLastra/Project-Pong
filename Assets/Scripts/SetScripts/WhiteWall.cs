using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteWall : MonoBehaviour
{
    Renderer wallRenderer;

    private void OnEnable()
    {
        wallRenderer = GetComponent<Renderer>();
        wallRenderer.material.color = Color.white;
    }
}
