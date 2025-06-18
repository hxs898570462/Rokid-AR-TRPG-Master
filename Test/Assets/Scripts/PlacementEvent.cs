using UnityEngine;
using UnityEngine.EventSystems;
using Rokid.UXR.Interaction;
using Rokid.UXR.Utility;

[RequireComponent(typeof(EventsLogUtils))]  // ȷ��UI�������¼��������
public class UIInteractionSpawner : MonoBehaviour, IRayPointerEnter, IRayPointerExit, IPointerClickHandler
{
    [Header("Spawn Settings")]
    [SerializeField] private Vector3 fixedSpawnPosition = Vector3.zero;  // �̶�����λ��
    [SerializeField] private GameObject objectToSpawn;  // Ҫ���ɵ�Ԥ����
    [SerializeField] private float spawnDelay = 0.5f;  // �����ӳ٣���ֹ�󴥣�

    [Header("UI Feedback")]
    [SerializeField] private Material highlightMaterial;  // ��������
    private Material originalMaterial;
    private Renderer uiRenderer;

    private bool isHovering = false;
    private float hoverStartTime;

    private void Start()
    {
        // ��ȡUI����Ⱦ������ڸ�������
        uiRenderer = GetComponent<Renderer>();
        if (uiRenderer != null)
        {
            originalMaterial = uiRenderer.material;
        }

        // ȷ����EventSystem
        if (FindObjectOfType<EventSystem>() == null)
        {
            var eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
    }

    private void Update()
    {
        // ������ͣ���
        if (isHovering && Time.time - hoverStartTime >= spawnDelay)
        {
            SpawnObject();
            isHovering = false;
        }
    }

    // AR���߽���UIʱ����
    public void OnRayPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        hoverStartTime = Time.time;

        // ��������
        if (uiRenderer != null && highlightMaterial != null)
        {
            uiRenderer.material = highlightMaterial;
        }
    }

    // AR�����뿪UIʱ����
    public void OnRayPointerExit(PointerEventData eventData)
    {
        isHovering = false;

        // �ָ�ԭʼ����
        if (uiRenderer != null && originalMaterial != null)
        {
            uiRenderer.material = originalMaterial;
        }
    }

    // ���/�������UIʱ���ã����ݷ�AR���룩
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

        // ��ѡ���������Ч��
        Debug.Log($"Spawned object at {fixedSpawnPosition}");
    }

    // ��Scene��ͼ����ʾ�̶�λ�ñ��
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(fixedSpawnPosition, 0.1f);
        Gizmos.DrawWireCube(fixedSpawnPosition, Vector3.one * 0.2f);
    }
}
