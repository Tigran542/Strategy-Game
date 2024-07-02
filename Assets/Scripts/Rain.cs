using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public Light dirLight;
    private ParticleSystem _ps;
    private bool _isRain = false;

    private void Start()
    {
        _ps = GetComponent<ParticleSystem>();
        StartCoroutine(Weather());
    }


    private void Update()
    {
        if (_isRain && dirLight.intensity > 0.2f)
            LightIntensity(-1);
        if (!_isRain && dirLight.intensity < 0.5f)
            LightIntensity(1);
    }

    private void LightIntensity(int mult)
    {
        dirLight.intensity += 0.1f * Time.deltaTime * mult;
    }

    IEnumerator Weather()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(30f, 45f));


            if (_isRain)           
                _ps.Stop();             
            else            
                _ps.Play();
                

            _isRain = !_isRain;
        }
    }

}
