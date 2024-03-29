using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    [Header("Boost Controllers")]
    public float BoostRatio = 1;
    [SerializeField] private AnimationCurve BoostCurve;
    public bool IsBoosted;
    public bool IsCurrentlyBoosted;

    [Header("Juice")]
    [SerializeField] private ParticleSystem _boostFX;
    [SerializeField] private Animation _boostUIAnimation;
    [SerializeField] private AudioManager _audioManager;


    //Activate the Boost Coroutine to Lerp Speed
    void Update(){
        if (IsBoosted) {
            StartCoroutine(Boosted());
            IsBoosted = false;
            _boostUIAnimation.Play("BoostedAnimation");
            _audioManager.PlayBoosterSound();
        }
    }

    //Boost Lerp Coroutine controlled by Animation Curve
    IEnumerator Boosted()  {

        float lerpSpeed = 1f;
        var emission = _boostFX.emission;
        float time = 0;

        while (time < 1) {
            emission.rateOverDistance = 12.0f;
            BoostRatio = Mathf.Lerp(2.5f, 1f, BoostCurve.Evaluate(time));
            time += Time.deltaTime * lerpSpeed;
            yield return null;
        }

        if (time >= 1) {
            emission.rateOverDistance = 0.0f;
            BoostRatio = 1;
            time = 0;

        }
    }

}
