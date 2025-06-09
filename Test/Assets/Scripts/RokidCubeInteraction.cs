using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rokid;

public class RokidCubeInteraction : MonoBehaviour
{
    [SerializeField] private GameObject cube; // ���Ƶ�������

    private MeshRenderer meshRenderer;
    private Transform handTransform;
    private static readonly int ColorID = Shader.PropertyToID("_Color");

    private void Awake()
    {
        meshRenderer = cube.GetComponent<MeshRenderer>();
    }

    // �����屻����ʱ��������ɫ��Ϊ��ɫ
    public void OnHoverBegin()
    {
        meshRenderer.material.SetColor(ColorID, Color.blue);
    }

    // �����岻�ٱ�����ʱ��������ɫ�ָ�Ϊ��ɫ
    public void OnHoverEnd()
    {
        meshRenderer.material.SetColor(ColorID, Color.white);
    }

    // �����屻ץȡʱ��������ɫ��Ϊ��ɫ
    public void OnPickUp(Transform grabbedPoint)
    {
        meshRenderer.material.SetColor(ColorID, Color.red);

        // ץȡʱ����������ص��ֲ�λ��
        handTransform = grabbedPoint;
        cube.transform.SetParent(handTransform);
        cube.transform.localPosition = Vector3.zero;
        cube.transform.localRotation = Quaternion.identity;
    }

    // �����屻����ʱ��������ɫ�ָ�Ϊ��ɫ
    public void OnDropDown()
    {
        meshRenderer.material.SetColor(ColorID, Color.white);

        // ������º�ȡ��������
        cube.transform.SetParent(null);
    }

    // ��������ץȡʱ��ȷ����������ֲ�λ��
    public void OnHeldUpdate()
    {
        if (handTransform != null)
        {
            cube.transform.position = handTransform.position;
            cube.transform.rotation = handTransform.rotation;
        }
    }
}
