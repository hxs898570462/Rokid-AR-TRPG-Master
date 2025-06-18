using UnityEngine;
using UnityEngine.EventSystems;
using Rokid.UXR.Interaction;
using Rokid.UXR.Utility;

[RequireComponent(typeof(EventsLogUtils))]  // 确保UI物体有事件检测能力
public class UIInteractionSpawner : MonoBehaviour, IRayPointerEnter, IRayPointerExit, IPointerClickHandler
{
    [Header("Spawn Settings")]
    [SerializeField] private Vector3 fixedSpawnPosition = Vector3.zero;  // 固定生成位置
    [SerializeField] private GameObject objectToSpawn;  // 要生成的预制体
    [SerializeField] private float spawnDelay = 0.5f;  // 生成延迟（防止误触）

    [Header("UI Feedback")]
    [SerializeField] private Material highlightMaterial;  // 高亮材质
    private Material originalMaterial;
    private Renderer uiRenderer;

    private bool isHovering = false;
    private float hoverStartTime;

    private void Start()
    {
        // 获取UI的渲染组件用于高亮反馈
        uiRenderer = GetComponent<Renderer>();
        if (uiRenderer != null)
        {
            originalMaterial = uiRenderer.material;
        }

        // 确保有EventSystem
        if (FindObjectOfType<EventSystem>() == null)
        {
            var eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
    }

    private void Update()
    {
        // 持续悬停检测
        if (isHovering && Time.time - hoverStartTime >= spawnDelay)
        {
            SpawnObject();
            isHovering = false;
        }
    }

    // AR射线进入UI时调用
    public void OnRayPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        hoverStartTime = Time.time;

        // 高亮反馈
        if (uiRenderer != null && highlightMaterial != null)
        {
            uiRenderer.material = highlightMaterial;
        }
    }

    // AR射线离开UI时调用
    public void OnRayPointerExit(PointerEventData eventData)
    {
        isHovering = false;

        // 恢复原始材质
        if (uiRenderer != null && originalMaterial != null)
        {
            uiRenderer.material = originalMaterial;
        }
    }

    // 鼠标/触摸点击UI时调用（兼容非AR输入）
    public void OnPointerClick(PointerEventData eventData)
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        if (objectToSpawn == null)
        {
            Debug.LogWarning("No object to spawn assigned!");
            return;
        }

        Instantiate(objectToSpawn, fixedSpawnPosition, Quaternion.identity);

        // 可选：添加生成效果
        Debug.Log($"Spawned object at {fixedSpawnPosition}");
    }

    // 在Scene视图中显示固定位置标记
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(fixedSpawnPosition, 0.1f);
        Gizmos.DrawWireCube(fixedSpawnPosition, Vector3.one * 0.2f);
    }
}
