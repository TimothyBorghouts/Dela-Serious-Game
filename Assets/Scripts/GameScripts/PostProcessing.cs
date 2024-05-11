using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{

    public float saturationSteps;
    ColorGrading colorGradingLayer = null;
    PostProcessVolume volume;

    private void Start()
    {
        volume = gameObject.GetComponent<PostProcessVolume>();
        removeSat2();
    }

    public void removeSat2()
    {
        ColorGrading setting = volume.profile.GetSetting<ColorGrading>();
        SplineParameter hueVsSatCurve = setting.hueVsSatCurve;
        Spline spline = hueVsSatCurve.value;
        float[] cachedData = spline.cachedData;
        Debug.Log(cachedData.Length);

        for (int i = 0; i < cachedData.Length; i++)
        {
            cachedData[i] = 0f;
            Debug.Log(cachedData[i]);
        }

        hueVsSatCurve.value.cachedData = cachedData;

        setting.hueVsSatCurve = hueVsSatCurve;

        AnimationCurve curve = spline.curve;
        curve.AddKey(0, 0);

        volume.profile.RemoveSettings<ColorGrading>();

        setting.hueVsSatCurve.value.curve = curve;

        volume.profile.AddSettings(setting);
    }

    //public void removeSat3()
    //{
    //    volume.profile.TryGetSettings(out ColorGrading colorGrading);
    //    SplineParameter hueVsSatCurve = colorGrading.hueVsSatCurve;
    //    Spline spline = hueVsSatCurve.value;

    //    spline.curve = new AnimationCurve();

    //    for (int i = 0; i < spline.curve.keys.Length; i++)
    //    {
    //        Keyframe keyframe = spline.curve.keys[i];
    //        spline.curve.keys[i].value = 0;
    //        spline.curve.MoveKey(i, keyframe);
    //    }

    //    colorGrading.hueVsSatCurve.Override(spline);

    //}

    //public void removeSaturations()
    //{
    //    volume.profile.TryGetSettings(out colorGradingLayer);
    //    colorGradingLayer.saturation.value = -100f;
    //}

    //public void addSaturation()
    //{
    //    if (colorGradingLayer.saturation.value >= 0)
    //    {
    //        return;
    //    }
    //    volume.profile.TryGetSettings(out colorGradingLayer);
    //    colorGradingLayer.saturation.value += (100 / saturationSteps);
    //}

    //public void changeSatAndHue()
    //{
    //    ColorGrading setting = profile.GetSetting<ColorGrading>();
    //    SplineParameter hueVsSatCurve = setting.hueVsSatCurve;
    //    Debug.Log(hueVsSatCurve.value);
    //    Spline spline = hueVsSatCurve.value;
    //    float[] cachedData = spline.cachedData;
    //    Debug.Log(cachedData.Length);

    //    for (int i = 0; i < 100; i++)
    //    {
    //        cachedData[i] = 0.7f;
    //    }


    //    for (int i = 0; i < cachedData.Length; i++)
    //    {
    //        Debug.Log(cachedData[i]);
    //    }

    //    SplineParameter newHueVsSatCurve = new SplineParameter();

    //    hueVsSatCurve.value.cachedData = cachedData;

    //    setting.hueVsSatCurve = hueVsSatCurve;

    //    profile.AddSettings(setting);
    //}

}
