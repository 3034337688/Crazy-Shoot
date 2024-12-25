
using UnityEngine;

/// <summary>
/// 使用hash的方式代替字符串查找
/// </summary>
public static class AnimatorHash
{
    public static readonly int isPlayerWalk = Animator.StringToHash("is walk"); //readonly保持不可修改性
    public static readonly int isBeetleWalk = Animator.StringToHash("isBeetleWalk");
}
