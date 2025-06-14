using UnityEngine;
using UnityEngine.UI;

public class ConfirmButton : MonoBehaviour
{
    private GameObject modelToLock;

    public void Init(GameObject model)
    {
        modelToLock = model;
    }

    public void OnConfirmClick()
    {
        modelToLock.GetComponent<DragRotateController>().Lock();
        gameObject.SetActive(false);
    }
}
