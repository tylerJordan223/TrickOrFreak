using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    private Animator anim;

    [Header("Coloring")]
    [SerializeField] Color floor_col;
    [SerializeField] Color struct_col;
    [SerializeField] Color roof_col;
    [SerializeField] Color walls_col;

    [SerializeField] Material person_front;
    [SerializeField] Material person_back;

    private Renderer house_r;
    private Material[] _runtimeMaterials;

    private void Awake()
    {
        house_r = transform.Find("BaseHouseModel").GetComponent<Renderer>();
        if (house_r == null) return;

        var shared = house_r.sharedMaterials;
        _runtimeMaterials = new Material[shared.Length];

        for (int i = 0; i < shared.Length; i++)
        {
            if (shared[i] != null)
            {
                _runtimeMaterials[i] = new Material(shared[i]);
                _runtimeMaterials[i].name = shared[i].name + " (Instance)";
            }
        }

        house_r.sharedMaterials = _runtimeMaterials;
        ApplyColors();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void ApplyColors()
    {
        foreach (var mat in _runtimeMaterials)
        {
            if (mat == null) continue;

            if (mat.name.Contains("Wall"))
            {
                mat.color = walls_col;
            }
            if (mat.name.Contains("Floor")) mat.color = floor_col;
            if (mat.name.Contains("Material.014")) mat.color = struct_col;
            if (mat.name.Contains("Roof")) mat.color = roof_col;
        }

        //handle person
        var person = transform.Find("Person");
        person.GetChild(0).GetComponent<Renderer>().material = person_front;
        person.GetChild(1).GetComponent<Renderer>().material = person_back;
    }
}
