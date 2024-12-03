using UnityEngine;
using UnityEngine.EventSystems;

public class Openzapus1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject panel;
    private bool click = false;

    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    void Update()
    {
        if (click && Input.GetMouseButtonDown(0))
        {
            if (panel != null)
            {
                panel.SetActive(true);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        click = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        click = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
    }
}
