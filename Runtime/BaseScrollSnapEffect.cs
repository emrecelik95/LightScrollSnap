using UnityEngine;

namespace LightScrollSnap
{
    public abstract class BaseScrollSnapEffect : ScriptableObject
    {
        public float effectedDistanceBasedOnItemSize = 1;

        /// <summary>
        /// Called every frame
        /// </summary>
        /// <param name="transform">RectTransform</param>
        /// <param name="displacement">Shift distance, between -1, 1. 0 means item is snapped. 1 means item is on the most right, -1 means the opposite. </param>
        public abstract void OnItemUpdated(RectTransform transform, float displacement);

        /// <summary>
        /// Gives signed ratio based on shifting distance.
        /// Example -> displacement is -0.4f, then effect ratio will be -0.6f;
        /// Example -> displacement is  0.4f, then effect ratio will be 0.6f;
        /// </summary>
        /// <param name="displacement"></param>
        /// <returns></returns>
        protected float GetEffectRatio(float displacement) => displacement < 0 ? -1 - displacement : 1 - displacement;

        /// <summary>
        /// Gives absolute ratio based on shifting distance.
        /// Example -> displacement is -0.4f, then effect ratio will be 0.6f;
        /// Example -> displacement is  0.4f, then effect ratio will be 0.6f;
        /// </summary>
        /// <param name="displacement"></param>
        /// <returns></returns>
        protected float GetEffectRatioAbs(float displacement) => 1 - Mathf.Abs(displacement);
    }
}