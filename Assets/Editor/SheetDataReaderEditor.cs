using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using GoogleSheetsToUnity;

//Ŀ���� ������ �ۼ� ����
//��ũ��Ʈ�� ���� ����
//������ ������ ���ϰ� �۾��ؾ��ϴ� ���


#if UNITY_EDITOR
//�ش� �����ʹ� SheetDataReader.cs�� ���� Ŀ���� ������ �Դϴ�.
[CustomEditor(typeof(SheetDataReader))]
public class SheetDataReaderEditor : Editor
{
    SheetDataReader sheetData;

    //�ڵ� Ȱ��ȭ �ܰ迡�� �۾�
    private void OnEnable()
    {
        sheetData = (SheetDataReader)target;
        //��Ʈ�� �����ʹ� �����Ͱ� ���� ���� ������� ó���մϴ�.
 
    }

    //�ν����Ϳ� ���� ����
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); //���� �������� ������ �״�� ����մϴ�.

        //���̾ƿ��� �۾� �ۼ�
        GUILayout.Label("�������� ��Ʈ �ҷ�����");

        //��ư �ۼ�
        if (GUILayout.Button("������ �б�"))
        {
            //�۾��� ���� ����
            DataRead(ButtonAction);      //������ �б� �۾� ����
            sheetData.dataList.Clear(); //���� �����Ϳ� ���� �ʱ�ȭ
        }
    }
    private void ButtonAction(GstuSpreadSheet arg0)
    {
        //��Ʈ �����Ϳ� ���� ����ŭ �۾��� �����մϴ�.
        for(int i = sheetData.row_length_begin; i <= sheetData.row_length_end; i++)
        {
            sheetData.UpdateSheetData(arg0.rows[i], i);
        }
        EditorUtility.SetDirty(target); //�ش� ������Ʈ�� �����Ǿ����� ����Ƽ �����Ϳ� �˸��� ���
    }

    //GSTU���� �������ִ� SpreadSheet�� ���� ����Ƽ �̺�Ʈ�� ���޹ް�, �۾��� �����մϴ�.
    //1. ���� �������� ��Ʈ�� Ư�� ��Ʈ�� ��ũ ��Ʈ�� �о���� �۾�
    private void DataRead(UnityAction<GstuSpreadSheet> callback)
    {
        SpreadsheetManager.Read(new GSTU_Search(sheetData.address, sheetData.worksheet),callback);
        //SpreadsheetManager.Read()�� �̿��� ���� ��Ʈ���� �����͸� �޾ƿ� �� �ֽ��ϴ�(�񵿱�)
        //GSTU_Search�� ���ؼ� �о ���������Ʈ�� ��ũ��Ʈ�� ������ ���ֽ��ϴ�.
    }
}
#endif