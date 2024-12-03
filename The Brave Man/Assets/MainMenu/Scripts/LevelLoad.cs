using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelLoad : MonoBehaviour, IPointerClickHandler
{
    // Додаємо зміну номеру сцени
    public int scene;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(scene);
    }
}
