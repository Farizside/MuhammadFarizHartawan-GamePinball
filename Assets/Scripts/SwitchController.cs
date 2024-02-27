using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    public float score;
    public Collider bola;
    public Material offMaterial;
    public Material onMaterial;
    public AudioManager audioManager;
    public VFXManager vfxManager;
    public ScoreManager scoreManager;

    private SwitchState _state;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        Set(false);

        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            Toggle();
            audioManager.PlaySFX(other.transform.position);
            vfxManager.PlayVFX(other.transform.position);
        }
    }

    private void Set(bool active)
    {
        if (active == true)
        {
            _state = SwitchState.On;
            _renderer.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            _state = SwitchState.Off;
            _renderer.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private void Toggle()
    {
        scoreManager.AddScore(score);
        if (_state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }

    private IEnumerator Blink(int times)
    {
        _state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            _renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            _renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        _state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
