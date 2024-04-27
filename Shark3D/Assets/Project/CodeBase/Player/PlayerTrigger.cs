using Assets.Project.CodeBase.Fish;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Fish fish))
        {
            Debug.Log("Соприкосновение произошло");
            fish.Destroys();
        }
    }
}