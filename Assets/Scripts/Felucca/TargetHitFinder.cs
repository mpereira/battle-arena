using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Felucca {
    public static class TargetHitFinder {
        private static readonly RaycastHit[] HitResults = new RaycastHit[10];
        private static readonly Camera _camera;

        static TargetHitFinder() {
            _camera = Camera.main;
        }

        public static RaycastHit? TargetHit(bool checkPointerOverGameObject) {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (checkPointerOverGameObject && EventSystem.current.IsPointerOverGameObject()) {
                return null;
            }

            Physics.RaycastNonAlloc(
                ray,
                HitResults,
                Mathf.Infinity,
                Physics.DefaultRaycastLayers
            );

            return HitResults.First();
        }
    }
}