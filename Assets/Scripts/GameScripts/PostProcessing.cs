using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{

    public float saturationSteps;
    PostProcessVolume volume;

    private float _borderRedOrange = 0.04f;
    private float _borderOrangeYellow = 0.10f;
    private float _borderYellowGreen = 0.21f;
    private float _borderGreenBlue = 0.46f;
    private float _borderBluePurple = 0.66f;
    private float _borderPurpleRed = 0.87f;

    private void Start()
    {
        volume = gameObject.GetComponent<PostProcessVolume>();
        Add0KeysToHue();
    }

    private void AddKeysToHue(Tuple<float, float>[] borders)
    {
        ColorGrading colorGrading = volume.profile.GetSetting<ColorGrading>();

        AnimationCurve curve = colorGrading.hueVsSatCurve.value.curve;

        foreach (var border in borders)
        {
            Keyframe key = new Keyframe(border.Item1, border.Item2);
            key.inWeight = 1;
            key.outWeight = 1;
            curve.AddKey(key);
        }

        volume.profile.RemoveSettings<ColorGrading>();
        colorGrading.hueVsSatCurve.value.curve = curve;
        volume.profile.AddSettings(colorGrading);
    }

    // NOTE: keys may not overlap, so small values were added to make sure they don't

    public void Add0KeysToHue()
    {
        var borders = new Tuple<float, float>[]
        {
            new Tuple<float, float>(0, 0),
            new Tuple<float, float>(1, 0)
        };
        AddKeysToHue(borders);
    }

    public void AddRedKeysToHue(){
        var borders = new Tuple<float, float>[]
        {
            new Tuple<float, float> (0 + 0.001f, 0.5f),
            new Tuple<float, float>(_borderRedOrange - 0.002f, 0.5f),
            new Tuple<float, float>(_borderRedOrange - 0.001f, 0),
            new Tuple<float, float>(_borderPurpleRed + 0.001f, 0),
            new Tuple<float, float>(_borderPurpleRed + 0.002f, 0.5f),
            new Tuple<float, float>(1 - 0.002f, 0.5f)
        };
        AddKeysToHue(borders);
    }

    public void AddOrangeKeysToHue()
    {
        var borders = new Tuple<float, float>[]
        {
            new Tuple<float, float>(_borderRedOrange, 0),
            new Tuple<float, float>(_borderRedOrange + 0.001f, 0.5f),
            new Tuple<float, float>(_borderOrangeYellow - 0.002f, 0.5f),
            new Tuple<float, float>(_borderOrangeYellow - 0.001f, 0)
        };
        AddKeysToHue(borders);
    }

    public void AddYellowKeysToHue()
    {
        var borders = new Tuple<float, float>[]
        {
            new Tuple<float, float>(_borderOrangeYellow, 0),
            new Tuple<float, float>(_borderOrangeYellow + 0.001f, 0.5f),
            new Tuple<float, float>(_borderYellowGreen - 0.002f, 0.5f),
            new Tuple<float, float>(_borderYellowGreen - 0.001f, 0)
        };
        AddKeysToHue(borders);
    }

    public void AddGreenKeysToHue()
    {
        var borders = new Tuple<float, float>[]
        {
            new Tuple<float, float>(_borderYellowGreen, 0),
            new Tuple<float, float>(_borderYellowGreen + 0.001f, 0.5f),
            new Tuple<float, float>(_borderGreenBlue - 0.002f, 0.5f),
            new Tuple<float, float>(_borderGreenBlue - 0.001f, 0)
        };
        AddKeysToHue(borders);
    }

    public void AddBlueKeysToHue()
    {
        var borders = new Tuple<float, float>[]
        {
            new Tuple<float, float>(_borderGreenBlue, 0),
            new Tuple<float, float>(_borderGreenBlue + 0.001f, 0.5f),
            new Tuple<float, float>(_borderBluePurple - 0.002f, 0.5f),
            new Tuple<float, float>(_borderBluePurple - 0.001f, 0)
        };
        AddKeysToHue(borders);
    }

    public void AddPurpleKeysToHue()
    {
        var borders = new Tuple<float, float>[]
        {
            new Tuple<float, float>(_borderBluePurple, 0),
            new Tuple<float, float>(_borderBluePurple + 0.001f, 0.5f),
            new Tuple<float, float>(_borderPurpleRed - 0.002f, 0.5f),
            new Tuple<float, float>(_borderPurpleRed - 0.001f, 0)
        };
        AddKeysToHue(borders);
    }

}
