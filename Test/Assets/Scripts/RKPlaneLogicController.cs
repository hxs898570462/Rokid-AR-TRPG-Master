using UnityEngine;
using UnityEngine.EventSystems;
using Rokid.UXR.Interaction;
using Rokid.UXR.Module;

public class RKPlaneLogicController : MonoBehaviour
{
    [Header("平面识别控制")]
    public PlaneTracking planeTracking;

    [Header("平面管理")]
    public ARPlaneManager arPlaneManager;

    [Header("模型放置参数")]
    public GameObject anchorPrefab;
    public bool followPlane;

    [Header("确认按钮Prefab")]
    public GameObject confirmButtonPrefab;

    [Header("放置完成后需要隐藏的UI")]
    public GameObject pointableUIButton;

    private void Start()
    {
        planeTracking.startTracking();
        RKPointerListener.OnPhysicalPointerDown += OnPointerDown;
    }

    private void OnDestroy()
    {
        RKPointerListener.OnPhysicalPointerDown -= OnPointerDown;
    }

    private void OnPointerDown(PointerEventData data)
    {
        var hitObj = data.pointerCurrentRaycast.gameObject;
        if (hitObj == null) return;

        ARPlane plane = hitObj.GetComponent<ARPlane>();
        if (plane != null)
        {
            Vector3 position = data.pointerCurrentRaycast.worldPosition;
            Quaternion rotation = hitObj.transform.rotation;

            GameObject anchor = Instantiate(anchorPrefab, position, rotation);
            anchor.SetActive(true);

            if (followPlane)
                anchor.transform.parent = plane.transform;
            else
                anchor.transform.parent = transform;

            // ✅ 正确传入 anchor
            OnModelPlaced(anchor);
        }
    }

    private void OnModelPlaced(GameObject anchor)
    {
        planeTracking.stopTracking();
        pointableUIButton.SetActive(false);
        RKPointerListener.OnPhysicalPointerDown -= OnPointerDown;

        GameObject confirmButton = Instantiate(confirmButtonPrefab);
        confirmButton.transform.SetParent(anchor.transform);
        confirmButton.transform.localPosition = new Vector3(0, 1.5f, 0);
        confirmButton.GetComponent<ConfirmButton>().Init(anchor);
    }
}
