using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelLoad : MonoBehaviour, IPointerClickHandler
{
    // ������ ���� ������ �����
    public int scene;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(scene);
    }
}
