using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <컴포넌트 요청> - RequireComponent, AddComponent, GetComponent
// # [RequireComponent (typeof(Rigidbody))] // 
// RequireComponent는 object에 Component가 계속 유지되고 값 바꾸고 계속 저장할 용도로 사용
// cf, 코드에서 처리 (AddComponent, GetComponent)-> 기획자들이 변수조정 필요 없고 필요할 때만 동적으로 처리할 때.

public class ComponentTest : MonoBehaviour
{
    private Rigidbody rb = null;
    private Transform[] trs = null;

    private void Awake()
    {
        // # AddComponent
        // ㄴ AddComponent는 어떤 gameObject에 이 component를 붙일 지 명시해 줘야 한다.
        // ㄴ cf, GetComponent
        // ㄴ tr = this.GetComponent<UnityEngine.Transform>(); // 이 스크립트가 붙어있는 obj(this)에서 Transform component 들고 옴
        rb = gameObject.AddComponent<Rigidbody>(); // 실시간으로 요청해서 사용할 때 Add/ GetComponent사용.
        // ㄴ AddComponent는 붙이는게 성공했으면 반환. <-> 이미 붙어있으면 붙이는거 실패했으니까 null반환한다.
        if (rb == null)
        {
            // # AddComponent vs GetComponent
            //Debug.LogError("Rigidbody is null!!"); // -> Rigidbody 있는 상태에서 gameObject.AddComponent<Rigidbody>();하면 null뜬다.
           GetComponent<Rigidbody>(); // Rigidbody가 이미 추가되어 있으면 그냥 GetComponent하면 됨.
        }
        // # GetComponentsInChildren
        // 나를 포함한 자식들이 가지고 있는 Transform컴포넌트들을 갖고와라
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

        // # Component찾고 gameObject 가져와서 활용하기
        Capsule capsule = GetComponentInChildren<Capsule>();
        Debug.Log("capsule: " + capsule.gameObject.name); // 캠슐 컴포넌트를 가져오면 해당 게임 오브젝트에 접근이 가능하고 , 활용 가능하다.

        // # gravity 제어
        Rigidbody capsuleRb = capsule.gameObject.AddComponent<Rigidbody>();
        capsuleRb.useGravity = false;
        // # Destroy(Component) vs Destory(Component.gameObject)
        //ㄴ Component넣으면 gameObject가 아니고 component를 넣고 Destroy하면 컴포넌트가 없어진다.
        //Destroy(capsule);

        



    }
}
