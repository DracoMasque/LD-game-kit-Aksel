using System.Collections;
using Gamekit3D;
using Unity.Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineCamera))]
public class CameraShot : MonoBehaviour
{
    public float duration = 3.5f;

    static CameraShot s_Current;

    CinemachineCamera m_Camera;
    bool m_Playing;

    void Awake()
    {
        m_Camera = GetComponent<CinemachineCamera>();
        m_Camera.enabled = false;
    }

    public void Play()
    {
        if (s_Current != null && s_Current.m_Playing) return;
        StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        s_Current = this;
        m_Playing = true;
        m_Camera.enabled = true;
        if (PlayerInput.Instance != null) PlayerInput.Instance.ReleaseControl();
        yield return new WaitForSeconds(duration);
        m_Camera.enabled = false;
        if (PlayerInput.Instance != null) PlayerInput.Instance.GainControl();
        m_Playing = false;
    }
}
