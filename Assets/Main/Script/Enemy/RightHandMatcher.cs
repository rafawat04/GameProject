using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandMatcher : MonoBehaviour
{
    private AvatarIKGoal ikGoal = AvatarIKGoal.RightHand; // IK制御を行う体の部分（今回は左手）
    [SerializeField] private Transform RightHandPoint;
    private Animator anim;
    public bool isEnableIK = true; // IK制御有効化フラグ
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnAnimatorIK() { // OnAnimatorIKはIK制御情報を更新する際に呼ばれるコールバック
        if (!isEnableIK)
            return;

        // 武器に作成したRightHandPointに、左手を移動させる
        anim.SetIKPositionWeight(ikGoal, 1f);
        anim.SetIKRotationWeight(ikGoal, 1f);
        anim.SetIKPosition(ikGoal, RightHandPoint.position);
        anim.SetIKRotation(ikGoal, RightHandPoint.rotation);
    }
}