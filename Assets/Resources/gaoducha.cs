using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class gaoducha : MonoBehaviour
{
    public GameObject cart;
    public PostProcessingBehaviour profil;
    public UnityEngine.PostProcessing.VignetteModel.Settings last;
    public UnityEngine.PostProcessing.ChromaticAberrationModel.Settings lastc;
    // Start is called before the first frame update
    public enum Mode
    {
        Classic,
        Masked
    }

    

    void Start()
    {
        last = profil.profile.vignette.settings;
        lastc = profil.profile.chromaticAberration.settings;

    }

    // Update is called once per frame
    public static UnityEngine.PostProcessing.ChromaticAberrationModel.Settings mySettingsc
    {
        get
        {
            return new UnityEngine.PostProcessing.ChromaticAberrationModel.Settings
            {
                spectralTexture = null,
                intensity = 1f
            };
        }
    }
    public UnityEngine.PostProcessing.VignetteModel.Settings mySettings;
   
    void Update()
    {
        if (cart.transform.rotation.z > 0)
        {
            mySettings = new UnityEngine.PostProcessing.VignetteModel.Settings
            {
                mode = UnityEngine.PostProcessing.VignetteModel.Mode.Classic,
                color = new Color(0f, 0f, 0f, 1f),
                center = new Vector2(0.5f, 0.5f),
                intensity = 0.4f + (cart.transform.rotation.z),
                smoothness = 0.42f,
                roundness = 1f,
                mask = null,
                opacity = 1f,
                rounded = false
            };
        }
        else
        {
            mySettings = new UnityEngine.PostProcessing.VignetteModel.Settings
            {
                mode = UnityEngine.PostProcessing.VignetteModel.Mode.Classic,
                color = new Color(0f, 0f, 0f, 1f),
                center = new Vector2(0.5f, 0.5f),
                intensity = 0.4f,
                smoothness = 0.42f,
                roundness = 1f,
                mask = null,
                opacity = 1f,
                rounded = false
            };
        }

        profil.profile.vignette.settings = mySettings;
        if (cart.transform.position.y >= 40)
        {
           
       
         profil.profile.chromaticAberration.settings = mySettingsc;
            //Debug.Log("ici");
        }
        if (profil.profile.chromaticAberration.settings.Equals(mySettingsc))
        {
            if (cart.transform.position.y <= 20)
            {
              
                profil.profile.chromaticAberration.settings = lastc;
            }
        }


    }
}
