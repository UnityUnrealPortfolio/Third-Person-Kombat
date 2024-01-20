using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private MeshRenderer targetRenderer;
    [SerializeField] private Color targetedColor;
    [SerializeField] private Color normalColor;

    private void Start()
    {
        normalColor = targetRenderer.material.color;
    }
    public void HandleTargeted()
    {
        targetRenderer.material.color = targetedColor;
    }
    public void HandleUntargeted()
    {
        targetRenderer.material.color= normalColor;
    }
}
