using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    [SerializeField] private List<Target> targets = new List<Target>();
    [SerializeField] public Target currentSelectedTarget;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Target>(out Target target))
        targets.Add(target);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Target>(out Target target))
        {
            if (targets.Contains(target))
                targets.Remove(target);
        }
    }

    public bool GetSelectedTarget()
    {
        if(targets.Count == 0) return false;
        else
        {
            currentSelectedTarget = targets[0];
            return true;
        }
    }
}
