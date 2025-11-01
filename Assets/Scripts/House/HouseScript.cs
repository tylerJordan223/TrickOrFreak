using Cinemachine;
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

    private CinemachineVirtualCamera door_cam;

    private Renderer house_r;
    private Material[] _runtimeMaterials;

    private GameObject dialogue_system;

    private void Awake()
    {
        dialogue_system = transform.Find("DialogueSystem").gameObject;
        door_cam = transform.Find("DoorCam").GetComponent<CinemachineVirtualCamera>();

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

    public void OpenDoor()
    {
        anim.SetBool("TrickOrTreat", true);
    }

    public void CloseDoor()
    {
        anim.SetBool("TrickOrTreat", false);
    }

    private void Update()
    {
        //if its enabled
        if (door_cam.Priority == 1)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ReturnToPlayer();
            }
        }
    }

    public void SwapToHouseCam()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        door_cam.Priority = 1;
    }

    public void ReturnToPlayer()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        door_cam.Priority = 0;
        WorldEffects.EnablePlayer();
    }
}
