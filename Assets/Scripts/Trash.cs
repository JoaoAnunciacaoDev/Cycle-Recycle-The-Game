using System;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] private TrashType type;

    public TrashType Type => type;
}
