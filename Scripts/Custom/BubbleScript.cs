using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BubbleScript : MonoBehaviour
{
    public Color32 shieldColor = new Color32(128, 255, 128, 255);

    public Transform Mesh;

    void OnDrawGizmos()
    {
        Material[] mymat = Mesh.GetComponent<Renderer>().sharedMaterials;
        mymat[0].SetColor("_EmissionColor", shieldColor);
    }
}
