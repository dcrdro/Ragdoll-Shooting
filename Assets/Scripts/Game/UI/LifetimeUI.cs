using System;
using UnityEngine;
using UnityEngine.UI;

public class LifetimeUI : UIBase
{
    [SerializeField] private MonoBehaviour timable; // as ITimable
    
    [SerializeField] private Image timeImage;

    private ITimable Timable => (ITimable) timable;

    private void Update()
    {
        float part = Timable.Current / Timable.Capacity;
        timeImage.fillAmount = part;
    }
}
