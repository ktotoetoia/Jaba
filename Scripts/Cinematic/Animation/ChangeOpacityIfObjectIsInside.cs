using System;
using UnityEngine;
using System.Collections;

public class ChangeOpacityIfObjectIsInside : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _time;
    private SpriteRenderer _renderer;
    private IEnumerator fade;
    private bool _isInside;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        bool isInsideThisFrame = _renderer.bounds.Contains(_target.position);

        if (!_isInside && isInsideThisFrame)
        {
            FadeIn();
        }

        if(_isInside && !isInsideThisFrame)
        {
            FadeOut();
        }

        _isInside = isInsideThisFrame;
    }


    private void FadeIn()
    {
        StopCoroutine();

        fade = Fade((a) => _renderer.color = new Color(1, 1, 1, 1 - _curve.Evaluate( a)), 0);

        StartCoroutine(fade);
    }

    private void FadeOut()
    {
        StopCoroutine();

        fade = Fade((a) => _renderer.color = new Color(1, 1, 1, Mathf.Max(_curve.Evaluate(a), _renderer.color.a)), _renderer.color.a);

        StartCoroutine(fade);
    }

    private void StopCoroutine()
    {
        if (fade != null)
        {
            StopCoroutine(fade);
        }
    }

    private IEnumerator Fade(Action<float> timeAction, float normalizedTime = 0)
    {
        float currentTime = 0;

        while (normalizedTime < 1)
        {
            currentTime += Time.deltaTime;
            normalizedTime = currentTime / _time;
            timeAction(normalizedTime);

            yield return null;
        }
    }
}