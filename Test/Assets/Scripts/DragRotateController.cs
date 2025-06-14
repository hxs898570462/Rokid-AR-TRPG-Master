using UnityEngine;
using Rokid.UXR.Interaction;

public class DragRotateController : MonoBehaviour, IRayDragToTarget
{
    private bool isLocked = false;

    public void OnRayDragToTarget(Vector3 targetPosition)
    {
        if (isLocked) return;

        // ��������ƽ������ƽ��
        targetPosition.y = transform.position.y;
        transform.position = targetPosition;
    }

    public void Rotate(float angle)
    {
        if (isLocked) return;

        transform.Rotate(Vector3.up, angle, Space.World);
    }

    public void Lock()
    {
        isLocked = true;
    }
}
