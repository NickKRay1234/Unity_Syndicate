using Infrastructure.Services;
using Infrastructure.Services.SaveLoads;
using UnityEngine;

namespace Logic
{
    public class SaveTrigger : MonoBehaviour
    {
        private ISaveLoadService _saveLoadService;
        public BoxCollider Collider;
        private void Awake()
        {
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _saveLoadService.SaveProgress();
            Debug.Log("Progress Saved.");
            gameObject.SetActive(false);
        }

        private void OnDrawGizmos()
        {
            if (!Collider) return;
            Gizmos.color = Color.green;
            Gizmos.DrawCube(transform.position + Collider.center, Collider.size);
        }
    }
}