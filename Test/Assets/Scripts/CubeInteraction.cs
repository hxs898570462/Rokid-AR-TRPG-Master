using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CubeInteraction : MonoBehaviour
{
    [SerializeField] private GameObject cube; // 要控制的立方体
    [SerializeField] private Transform rightHandGrabbedPoint; // 手部的抓取点

    private MeshRenderer meshRenderer;
    private static readonly int Color1 = Shader.PropertyToID("_Color");
    private Transform handTransform;
    private bool isHeld = false;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void OnHoverBegin()
    {
        meshRenderer.material.SetColor(Color1, UnityEngine.Color.blue);
    }

    public void OnHoverEnd()
    {
        meshRenderer.material.SetColor(Color1, UnityEngine.Color.white);
    }

    public void OnPickUp(Transform grabbedPoint)
    {
        meshRenderer.material.SetColor(Color1, UnityEngine.Color.red);
        handTransform = grabbedPoint;
        transform.SetParent(handTransform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void OnDropDown()
    {
        meshRenderer.material.SetColor(Color1, UnityEngine.Color.white);
        transform.SetParent(null);
    }

    public void OnHeldUpdate()
    {
        if (handTransform != null)
        {
            transform.position = handTransform.position;
            transform.rotation = handTransform.rotation;
        }
    }
}