using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DizzyEffect : MonoBehaviour
{
    public Material _dizzyEffectMaterial;
    private bool _dizzyEffectEnabled = false;
    private float _frequency = 3f;
    private float _shift = 0f;
    private float _amplitude = 0f;
    private float _maxAmplitude = 0.075f;
    private float _amplitudeSpeed = 0.025f;
    private float _shiftSpeed = 3f;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, _dizzyEffectMaterial);
    }

    private void Start()
    {
        setFrequency(1f);
        setShift(_shift);
        setAmplitude(0f);
    }

    private void setFrequency(float frequency)
    {
        _dizzyEffectMaterial.SetFloat("_frequency", frequency);
    }

    private void setShift(float shift)
    {
        _dizzyEffectMaterial.SetFloat("_shift", shift);
    }

    private void setAmplitude(float amplitude)
    {
        _dizzyEffectMaterial.SetFloat("_amplitude", amplitude);
    }

    public void startDizzy()
    {
        _dizzyEffectEnabled = true;
        StartCoroutine(DizzyCoroutine());
    }
    public void stopDizzy()
    {
        _dizzyEffectEnabled = false;
    }

    private IEnumerator DizzyCoroutine()
    {
        setFrequency(_frequency);
        setShift(_shift);

        while(_amplitude < _maxAmplitude)
        {
            _amplitude += _amplitudeSpeed * Time.deltaTime;
            _shift += _shiftSpeed * Time.deltaTime;
            setShift(_shift);
            setAmplitude(_amplitude);
            yield return null;
        }
        _amplitude = _maxAmplitude;
        setAmplitude(_amplitude);

        while (_dizzyEffectEnabled)
        {
            _shift += _shiftSpeed * Time.deltaTime;
            setShift(_shift);
            yield return null;
        }

        while (_amplitude > 0f)
        {
            _amplitude -= _amplitudeSpeed * Time.deltaTime;
            _shift += _shiftSpeed * Time.deltaTime;
            setShift(_shift);
            setAmplitude(_amplitude);
            yield return null;
        }
        _amplitude = 0;
        setAmplitude(_amplitude);
        _shift = 0f;
        setShift(_shift);
    }
}
