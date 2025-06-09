using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rokid;

public class RokidCubeInteraction : MonoBehaviour
{
    [SerializeField] private GameObject cube; // 控制的立方体

    private MeshRenderer meshRenderer;
    private Transform handTransform;
    private static readonly int ColorID = Shader.PropertyToID("_Color");

    private void Awake()
    {
        meshRenderer = cube.GetComponent<MeshRenderer>();
    }

    // 当物体被触碰时，物体颜色变为蓝色
    public void OnHoverBegin()
    {
        meshRenderer.material.SetColor(ColorID, Color.blue);
    }

    // 当物体不再被触碰时，物体颜色恢复为白色
    public void OnHoverEnd()
    {
        meshRenderer.material.SetColor(ColorID, Color.white);
    }

    // 当物体被抓取时，物体颜色变为红色
    public void OnPickUp(Transform grabbedPoint)
    {
        meshRenderer.material.SetColor(ColorID, Color.red);

        // 抓取时，将物体挂载到手部位置
        handTransform = grabbedPoint;
        cube.transform.SetParent(handTransform);
        cube.transform.localPosition = Vector3.zero;
        cube.transform.localRotation = Quaternion.identity;
    }

    // 当物体被放下时，物体颜色恢复为白色
    public void OnDropDown()
    {
        meshRenderer.material.SetColor(ColorID, Color.white);

        // 物体放下后，取消父物体
        cube.transform.SetParent(null);
    }

    // 持续更新抓取时，确保物体跟随手部位置
    public void OnHeldUpdate()
    {
        if (handTransform != null)
        {
            cube.transform.position = handTransform.position;
            cube.transform.rotation = handTransform.rotation;
        }
    }
}
