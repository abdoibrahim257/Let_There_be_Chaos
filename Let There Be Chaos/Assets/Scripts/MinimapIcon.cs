using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minimap
{
    public class MinimapIcon : MonoBehaviour
    {

        private Vector3 baseScale;
        private void Start()
        {
            baseScale = transform.localScale;
            MinimapClass.OnZoomChanged += Minimap_OnZoomChanged;
        }

        private void Minimap_OnZoomChanged(object sender, System.EventArgs e)
        {
            // transform.localScale = baseScale * MinimapClass.GetZoom() / 1800f;
            // dh elly by-scale el 7aga upon zooming in/out, bs msh 3aref a3mlo fine-tuning
            // rakam 180 dh msh zabet, w grbt arkam tanya kteer brdo
            // 8albn h5ly kol el sprites bta3t el MiniMapIcon nafs el 7ag w 5las
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }

}