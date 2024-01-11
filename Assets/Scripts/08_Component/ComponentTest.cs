using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <������Ʈ ��û> - RequireComponent, AddComponent, GetComponent
// # [RequireComponent (typeof(Rigidbody))] // 
// RequireComponent�� object�� Component�� ��� �����ǰ� �� �ٲٰ� ��� ������ �뵵�� ���
// cf, �ڵ忡�� ó�� (AddComponent, GetComponent)-> ��ȹ�ڵ��� �������� �ʿ� ���� �ʿ��� ���� �������� ó���� ��.

public class ComponentTest : MonoBehaviour
{
    private Rigidbody rb = null;
    private Transform[] trs = null;

    private void Awake()
    {
        // # AddComponent
        // �� AddComponent�� � gameObject�� �� component�� ���� �� ����� ��� �Ѵ�.
        // �� cf, GetComponent
        // �� tr = this.GetComponent<UnityEngine.Transform>(); // �� ��ũ��Ʈ�� �پ��ִ� obj(this)���� Transform component ��� ��
        rb = gameObject.AddComponent<Rigidbody>(); // �ǽð����� ��û�ؼ� ����� �� Add/ GetComponent���.
        // �� AddComponent�� ���̴°� ���������� ��ȯ. <-> �̹� �پ������� ���̴°� ���������ϱ� null��ȯ�Ѵ�.
        if (rb == null)
        {
            // # AddComponent vs GetComponent
            //Debug.LogError("Rigidbody is null!!"); // -> Rigidbody �ִ� ���¿��� gameObject.AddComponent<Rigidbody>();�ϸ� null���.
           GetComponent<Rigidbody>(); // Rigidbody�� �̹� �߰��Ǿ� ������ �׳� GetComponent�ϸ� ��.
        }
        // # GetComponentsInChildren
        // ���� ������ �ڽĵ��� ������ �ִ� Transform������Ʈ���� ����Ͷ�
        trs = GetComponentsInChildren<Transform>();
        Debug.Log("trs Length : " + trs.Length);
        //foreach (Transform tr in trs)
        for (int i = 0; i < trs.Length; i++)
        {
            Debug.Log(trs[i].name);
        }
        Transform childtr =
            GetComponentInChildren<Transform>();
        Debug.Log("childTr: " + childtr.name);

        // # Componentã�� gameObject �����ͼ� Ȱ���ϱ�
        Capsule capsule = GetComponentInChildren<Capsule>();
        Debug.Log("capsule: " + capsule.gameObject.name); // ķ�� ������Ʈ�� �������� �ش� ���� ������Ʈ�� ������ �����ϰ� , Ȱ�� �����ϴ�.

        // # gravity ����
        Rigidbody capsuleRb = capsule.gameObject.AddComponent<Rigidbody>();
        capsuleRb.useGravity = false;
        // # Destroy(Component) vs Destory(Component.gameObject)
        //�� Component������ gameObject�� �ƴϰ� component�� �ְ� Destroy�ϸ� ������Ʈ�� ��������.
        //Destroy(capsule);

        



    }
}
