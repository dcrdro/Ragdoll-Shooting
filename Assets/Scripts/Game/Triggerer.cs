﻿using UnityEngine;

public class Triggerer : MonoBehaviour
{
    [SerializeField] private TriggerSender2D trigger;
    [SerializeField] private MonoBehaviour triggerable; // as ITriggerable

    private ITriggerable Triggerable => (ITriggerable) triggerable;

    void OnEnable()
    {
        trigger.OnEnter += OnEnter;
    }

    void OnDisable()
    {
        trigger.OnEnter -= OnEnter;
    }

    private void OnEnter(Collider2D obj)
    {
        Triggerable.OnTrigger();
    }
}
