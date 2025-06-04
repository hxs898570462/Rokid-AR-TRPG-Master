using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteraction : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    private static readonly int Color1 = Shader.PropertyToID("_Color");
    public void OnHoverBegin()
    {
        cube.GetComponent<MeshRenderer>().material.SetColor(Color1, Color.blue);
    }

    public void OnHoverEnd()
    {
        cube.GetComponent<MeshRenderer>().material.SetColor(Color1, Color.white);
    }

    public void OnPickUp()
    {
        cube.GetComponent<MeshRenderer>().material.SetColor(Color1, Color.red);
    }

    public void OnDropDown()
    {
        cube.GetComponent<MeshRenderer>().material.SetColor(Color1, Color.white);
    }
}
