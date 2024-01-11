using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraidPlayer : MonoBehaviour
{
    public enum EAnim { Idle, Run, Len, None }
    [SerializeField]
    private Sprite[] clipIdle = null; // Idle은 빈둥빈둥한 애니메이션
    [SerializeField]
    private Sprite[] clipRun = null;

    private Sprite[] curClip = null;

    // 기본 애니메이션 enum 타입 설정
    private EAnim curAnim = EAnim.None;
    private SpriteRenderer sr = null;

    private int curFrame = 0; // 현재 몇번째 프레임을 렌더링하고있는지 정보 저장할 변수
    private float changeTime = 0f; // 프레임을 바꾸기 위해 필요한 시간
    private float elapsedTime = 0f; // 누적시간.  시간이 될 때마다 프레임 일정하게 증가시켜줄 것.
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        SetAnimationClip(EAnim.Idle);
    }
    private void Update()
    {
        float axisH = Input.GetAxis("Horizontal");
        // Idle or Run 애니메이션 변경
        if (axisH < 0f || axisH > 0f)
            SetAnimationClip(EAnim.Run);
        else
            SetAnimationClip(EAnim.Idle);

        // 방향키 왼쪽 vs 오른쪽 입력에 따른 애니메이션 이미지 방향 설정
        if (axisH < 0f) sr.flipX = true;
        else if (axisH > 0f) sr.flipX = false;

        UpdateAnimation();
    }

    // enum type받아서 애니메이션 바꿔주는 함수
    private void SetAnimationClip(EAnim _anim)
    {
        // 기존 애니메이션이랑 바꿔줄 애니메이션이 같으면 애니메이션 안바꿔준다.
        if (curAnim == _anim) return;
        curAnim = _anim;

        switch (_anim)
        {
            case EAnim.Idle:
                curClip = clipIdle;
                break;
            case EAnim.Run:
                curClip = clipRun;
                break;
        }
        // 애니메이션이 바뀔 때 마다 초기화 되어야 하는 것들 전부 초기화 해 준다.
        // 한 애니메이션을 1초동안 돌려주는게 보통 자연스러움.
        // 그래서 sprite이미지(frame) 변환 기준은 1 / curClip.Length
        changeTime = 1f / curClip.Length;
        curFrame = 0;
        elapsedTime = 0f;
        // 애니메이션 전환된 후 처음이미지 reset
        sr.sprite = curClip[curFrame];
    } // end of SetAnimationClip()

    private void UpdateAnimation()
    {
        // 시작하면 Update에서 애니메이션 돌린다.
        // 시간 누적해서 프레임 바뀌어야 할 시간이 되면 프레임 바꿔준다.
        // 그 시간은 Start에서 미리 계산

        // 시간 계속 누적하다가 이 시간이 changeTime보다 커지면 사진 바꿔줌
        // 마지막프레임에서는 처음 프레임으로 바꿔준다. -> % 연산
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= changeTime)
        {
            ++curFrame;
            curFrame %= curClip.Length;
            sr.sprite = curClip[curFrame];
            // 이미지 바꿨으니까 elapsedTime 리셋
            elapsedTime = 0f;
        }
    }
} // end of class BraidPlayer
