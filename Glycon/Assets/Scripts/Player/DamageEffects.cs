using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DamageEffects : MonoBehaviour
{
    [Header("Damage effects")]
    public VolumeProfile volumeProfile;
    private Vignette vignette;
    public string componentName;
    public bool enableComponent= true;

    [Header("Audio")]
    public AudioSource injuryAudio;

    void Start()
    {
        // Finds the required volume component in the volume.
        for (int i = 0; i < volumeProfile.components.Count; i++)
        {

            if (volumeProfile.components[i].name == componentName)
            {
                vignette = (Vignette)volumeProfile.components[i];
            }
        }     
    }

    public void ChangeEffect()
    {
        injuryAudio.Play();
        StartCoroutine(ChangeVignette());
    }

    // CHanges the vignetter color override for a few seconds.
    private IEnumerator ChangeVignette()
    {
        vignette.color.Override(Color.red);
        vignette.intensity.Override(0.4f);
        yield return new WaitForSeconds(3f);
        vignette.color.Override(Color.black);
        vignette.intensity.Override(0.2f);
    }
}
