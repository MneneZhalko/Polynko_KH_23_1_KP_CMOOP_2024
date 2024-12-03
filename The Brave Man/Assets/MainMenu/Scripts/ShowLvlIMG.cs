using UnityEngine;
using UnityEngine.EventSystems;

// ������ ��� ����������� ������� ��������� ����� �� �����
public class ShowLvlIMG : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] GameObject LockedFirstLvlIMG;

    void Start()
    {
        // ��� ����� �������� ������ �������� ��������
        LockedFirstLvlIMG.SetActive(false);
    }

    // ��� ���� ���� � �������� �������
    public void OnPointerEnter(PointerEventData eventData)
    {
        // ������� ������
        LockedFirstLvlIMG.SetActive(true);
    }
}