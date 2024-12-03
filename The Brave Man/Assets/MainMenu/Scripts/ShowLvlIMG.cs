using UnityEngine;
using UnityEngine.EventSystems;

// Скрипт для відображення анімації наведення мишею на рівень
public class ShowLvlIMG : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] GameObject LockedFirstLvlIMG;

    void Start()
    {
        // При старті вимкнути спрайт наведеної текстури
        LockedFirstLvlIMG.SetActive(false);
    }

    // При вході миші у колайдер спрайту
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Вмикаємо спрайт
        LockedFirstLvlIMG.SetActive(true);
    }
}