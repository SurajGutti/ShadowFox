using UnityEngine;
using UnityEngine.UI;

public class Scripts_ManaBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxMana(int shadow)
    {
        slider.maxValue = shadow;
        slider.value = shadow;
    }

    public void SetMana(int shadow)
    {
        slider.value = shadow;
    }
}
