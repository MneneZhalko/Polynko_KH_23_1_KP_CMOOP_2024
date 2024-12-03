using UnityEngine;
using UnityEngine.EventSystems;

// Продовження скрипту для відображення анімації наведення мишею на рівень
public class ShowingLockedLvlIMG : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject LockedFirstLvlIMG;

    // Для запобігання ефекту миготливості, який утворюється через те, що миша виходить із колайдеру першого спрайту при появі другого,
    // утримуємо значення ввімкненого об'єкта на true, але вже коли миша наведена саме на другий спрайт
    public void OnPointerEnter(PointerEventData eventData)
    {
        LockedFirstLvlIMG.SetActive(true);
    }

    // Вимикаємо другий спрайт коли миша виходить з області
    public void OnPointerExit(PointerEventData eventData)
    {
        LockedFirstLvlIMG.SetActive(false);
    }
}