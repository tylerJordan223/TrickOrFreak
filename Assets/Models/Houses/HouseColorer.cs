using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class HouseColorer : MonoBehaviour
{
    [SerializeField] Color floor_col;
    [SerializeField] Color struct_col;
    [SerializeField] Color roof_col;
    [SerializeField] Color walls_col;

    private Renderer r;
    private Material[] _runtimeMaterials;

    private void Awake()
    {
        r = GetComponent<Renderer>();
        if (r == null) return;

        var shared = r.sharedMaterials;
        _runtimeMaterials = new Material[shared.Length];

        for (int i = 0; i < shared.Length; i++)
        {
            if (shared[i] != null)
            {
                _runtimeMaterials[i] = new Material(shared[i]);
                _runtimeMaterials[i].name = shared[i].name + " (Instance)";
            }
        }

        r.sharedMaterials = _runtimeMaterials;
        ApplyColors();
    }

    private void ApplyColors()
    {
        foreach(var mat in _runtimeMaterials)
        {
            if(mat == null) continue;

            if (mat.name.Contains("Wall"))
            {
                mat.color = walls_col;
            }
            if (mat.name.Contains("Floor")) mat.color = floor_col;
            if (mat.name.Contains("Material.014")) mat.color = struct_col;
            if (mat.name.Contains("Roof")) mat.color = roof_col;

        }
    }

}
