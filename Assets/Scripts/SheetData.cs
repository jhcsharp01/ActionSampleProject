using UnityEngine;

public class SheetData : ScriptableObject
{
    [SerializeField] public string address;  //��Ʈ �ּ�
    [SerializeField] public string worksheet; //��ũ ��Ʈ ����
    [SerializeField] public int row_length_begin;    //���� �� ��ȣ
    [SerializeField] public int row_length_end; //������ �� ��ȣ
}
