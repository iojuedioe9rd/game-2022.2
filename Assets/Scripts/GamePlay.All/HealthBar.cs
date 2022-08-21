using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.All
{
    public class HealthBar : MonoBehaviour
    {
        public HealthSystem healthSystem;

        public Transform BarTransform;

        public void Setup(HealthSystem healthSystem)
        {
            this.healthSystem = healthSystem;

            if(BarTransform == null)
            {
                BarTransform = transform.Find("Bar");
            }
        }

        private void Update()
        {
            #region SetScale
            BarTransform.localScale = new Vector3(BarTransform.localScale.x * healthSystem.GetHealthPercent(),
            BarTransform.localScale.y,
            BarTransform.localScale.z);
            #endregion


        }
    }
}
