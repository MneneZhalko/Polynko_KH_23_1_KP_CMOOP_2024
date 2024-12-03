using UnityEngine;
using UnityEngine.EventSystems;

// ����������� ������� ��� ����������� ������� ��������� ����� �� �����
public class ShowingLockedLvlIMG : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject LockedFirstLvlIMG;

    // ��� ���������� ������ �����������, ���� ����������� ����� ��, �� ���� �������� �� ��������� ������� ������� ��� ���� �������,
    // �������� �������� ���������� ��'���� �� true, ��� ��� ���� ���� �������� ���� �� ������ ������
    public void OnPointerEnter(PointerEventData eventData)
    {
        LockedFirstLvlIMG.SetActive(true);
    }

    // �������� ������ ������ ���� ���� �������� � ������
    public void OnPointerExit(PointerEventData eventData)
    {
        LockedFirstLvlIMG.SetActive(false);
    }
}