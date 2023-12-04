using UnityEngine;
using UnityEngine.UI;
using TMPro;
public abstract class Subject : MonoBehaviour
{
    [SerializeField] protected string subName;
    [SerializeField] protected GameObject dialogueBox;
    [SerializeField] protected TextMeshProUGUI textName;
    [SerializeField] protected TextMeshProUGUI text;
    private RayPhysics _RayPhys;
    protected float _maxDistance = 2;
  
    public abstract void Interaction();

    protected virtual void RayDraw()
    {
        if (Physics.Raycast(_RayPhys._Ray, out _RayPhys._hit, _maxDistance)) {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interaction();
            }
        };
    }
}
