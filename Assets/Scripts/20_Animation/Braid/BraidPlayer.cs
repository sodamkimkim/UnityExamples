using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraidPlayer : MonoBehaviour
{
    public enum EAnim { Idle, Run, Len, None }
    [SerializeField]
    private Sprite[] clipIdle = null; // Idle�� ��պ���� �ִϸ��̼�
    [SerializeField]
    private Sprite[] clipRun = null;

    private Sprite[] curClip = null;

    // �⺻ �ִϸ��̼� enum Ÿ�� ����
    private EAnim curAnim = EAnim.None;
    private SpriteRenderer sr = null;

    private int curFrame = 0; // ���� ���° �������� �������ϰ��ִ��� ���� ������ ����
    private float changeTime = 0f; // �������� �ٲٱ� ���� �ʿ��� �ð�
    private float elapsedTime = 0f; // �����ð�.  �ð��� �� ������ ������ �����ϰ� ���������� ��.
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
        // Idle or Run �ִϸ��̼� ����
        if (axisH < 0f || axisH > 0f)
            SetAnimationClip(EAnim.Run);
        else
            SetAnimationClip(EAnim.Idle);

        // ����Ű ���� vs ������ �Է¿� ���� �ִϸ��̼� �̹��� ���� ����
        if (axisH < 0f) sr.flipX = true;
        else if (axisH > 0f) sr.flipX = false;

        UpdateAnimation();
    }

    // enum type�޾Ƽ� �ִϸ��̼� �ٲ��ִ� �Լ�
    private void SetAnimationClip(EAnim _anim)
    {
        // ���� �ִϸ��̼��̶� �ٲ��� �ִϸ��̼��� ������ �ִϸ��̼� �ȹٲ��ش�.
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
        // �ִϸ��̼��� �ٲ� �� ���� �ʱ�ȭ �Ǿ�� �ϴ� �͵� ���� �ʱ�ȭ �� �ش�.
        // �� �ִϸ��̼��� 1�ʵ��� �����ִ°� ���� �ڿ�������.
        // �׷��� sprite�̹���(frame) ��ȯ ������ 1 / curClip.Length
        changeTime = 1f / curClip.Length;
        curFrame = 0;
        elapsedTime = 0f;
        // �ִϸ��̼� ��ȯ�� �� ó���̹��� reset
        sr.sprite = curClip[curFrame];
    } // end of SetAnimationClip()

    private void UpdateAnimation()
    {
        // �����ϸ� Update���� �ִϸ��̼� ������.
        // �ð� �����ؼ� ������ �ٲ��� �� �ð��� �Ǹ� ������ �ٲ��ش�.
        // �� �ð��� Start���� �̸� ���

        // �ð� ��� �����ϴٰ� �� �ð��� changeTime���� Ŀ���� ���� �ٲ���
        // �����������ӿ����� ó�� ���������� �ٲ��ش�. -> % ����
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= changeTime)
        {
            ++curFrame;
            curFrame %= curClip.Length;
            sr.sprite = curClip[curFrame];
            // �̹��� �ٲ����ϱ� elapsedTime ����
            elapsedTime = 0f;
        }
    }
} // end of class BraidPlayer
