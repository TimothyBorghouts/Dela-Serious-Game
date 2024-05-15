using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{

    public static PostProcessing Instance;

    public float saturationSteps;
    PostProcessVolume volume;

    private float _borderRedOrange = 0.04f;
    private float _borderOrangeYellow = 0.10f;
    private float _borderYellowGreen = 0.21f;
    private float _borderGreenBlue = 0.46f;
    private float _borderBluePurple = 0.66f;
    private float _borderPurpleRed = 0.87f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        volume = gameObject.GetComponent<PostProcessVolume>();
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
    public void AddKeysToHue()
    {
        Debug.Log("Adding keys to hue");
        var borders = new Tuple<float, float>[]
        {
            new Tuple<float, float>(0, 0), // 0
            new Tuple<float, float> (0 + 0.001f, 0), // 1

            new Tuple<float, float>(_borderRedOrange - 0.002f, 0), // 2
            new Tuple<float, float>(_borderRedOrange - 0.001f, 0), // 3
            new Tuple<float, float>(_borderRedOrange, 0), // 4
            new Tuple<float, float>(_borderRedOrange + 0.001f, 0), // 5

            new Tuple<float, float>(_borderOrangeYellow - 0.002f, 0), // 6
            new Tuple<float, float>(_borderOrangeYellow - 0.001f, 0), // 7
            new Tuple<float, float>(_borderOrangeYellow, 0), // 8
            new Tuple<float, float>(_borderOrangeYellow + 0.001f, 0), // 9

            new Tuple<float, float>(_borderYellowGreen - 0.002f, 0), // 10
            new Tuple<float, float>(_borderYellowGreen - 0.001f, 0), // 11
            new Tuple<float, float>(_borderYellowGreen, 0), // 12
            new Tuple<float, float>(_borderYellowGreen + 0.001f, 0), // 13

            new Tuple<float, float>(_borderGreenBlue - 0.002f, 0), // 14
            new Tuple<float, float>(_borderGreenBlue - 0.001f, 0), // 15
            new Tuple<float, float>(_borderGreenBlue, 0), // 16
            new Tuple<float, float>(_borderGreenBlue + 0.001f, 0), // 17

            new Tuple<float, float>(_borderBluePurple - 0.002f, 0), // 18
            new Tuple<float, float>(_borderBluePurple - 0.001f, 0), // 19
            new Tuple<float, float>(_borderBluePurple, 0), // 20
            new Tuple<float, float>(_borderBluePurple + 0.001f, 0), // 21

            new Tuple<float, float>(_borderPurpleRed - 0.002f, 0), // 22
            new Tuple<float, float>(_borderPurpleRed - 0.001f, 0), // 23
            new Tuple<float, float>(_borderPurpleRed, 0), // 24
            new Tuple<float, float>(_borderPurpleRed + 0.001f, 0), // 25

            new Tuple<float, float>(1 - 0.001f, 0), // 26
            new Tuple<float, float>(1, 0) // 27
        };
        AddKeysToHue(borders);
    }

    public void IncreaseSaturationPerColor(int[] indices)
    {
        ColorGrading colorGrading = volume.profile.GetSetting<ColorGrading>();

        AnimationCurve curve = colorGrading.hueVsSatCurve.value.curve;

        foreach (int i in indices)
        {
            Keyframe keyframe = curve.keys[i];
            keyframe.value = keyframe.value + 0.5f;
            if (keyframe.value > 0.5f)
            {
                keyframe.value = 0.5f;
            }
            curve.MoveKey(i, keyframe);
        }

        volume.profile.RemoveSettings<ColorGrading>();
        colorGrading.hueVsSatCurve.value.curve = curve;
        volume.profile.AddSettings(colorGrading);
    }

    public void IncreaseSaturation(int[] indices)
    {
        IncreaseBlueSaturation();
        IncreaseGreenSaturation();
        IncreaseOrangeSaturation();
        IncreasePurpleSaturation();
        IncreaseRedSaturation();
        IncreaseYellowSaturation();
    }
    

    public void IncreaseRedSaturation(){
        int[] indices = new int[] { 1, 2, 25, 26 };
        IncreaseSaturationPerColor(indices);
    }

    public void IncreaseOrangeSaturation()
    {
        int[] indices = new int[] { 5, 6 };
        IncreaseSaturationPerColor(indices);
    }

    public void IncreaseYellowSaturation()
    {
        int[] indices = new int[] { 9, 10 };
        IncreaseSaturationPerColor(indices);
    }

    public void IncreaseGreenSaturation()
    {
        int[] indices = new int[] { 13, 14 };
        IncreaseSaturationPerColor(indices);
    }

    public void IncreaseBlueSaturation()
    {
        int[] indices = new int[] { 17, 18 };
        IncreaseSaturationPerColor(indices);
    }

    public void IncreasePurpleSaturation()
    {
        int[] indices = new int[] { 21, 22 };
        IncreaseSaturationPerColor(indices);
    }

}
