using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    protected virtual bool DestroyTargetGameObj => false;

    /// <summary>
    /// ������ĂԂ��ƂŃN���X���擾�ł���B
    /// </summary>
    public static T I { get; private set; } = null;

    /// <summary>
    /// ���������������Ă��邩�̊m�F�p�B
    /// </summary>
    /// <returns>���������ł��Ă���ꍇ��True���Ԃ�B</returns>
    public static bool IsValid() => I != null;

    private static GameObject thisObj = null;

    public virtual void BattleSceneInit() { }
    public virtual void BattleSceneClear() { }

    /// <summary>
    /// Awake�ŌĂяo���B
    /// ���߂ČĂ΂���I�̂Ȃ��ɌĂ񂾃N���X���͂���B
    /// </summary>
    protected void Init()
    {
        if (I == null)
        {
            I = this as T;
            thisObj = I.gameObject;
            return;
        }
        if (gameObject == thisObj)
        {
            return;
        }
        if (DestroyTargetGameObj)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (I == this)
        {
            I = null;
        }
        OnRelease();
    }

    /// <summary>
    /// �p���N���X�p��Destroy�֐�
    /// </summary>
    protected virtual void OnRelease()
    {

    }
}
