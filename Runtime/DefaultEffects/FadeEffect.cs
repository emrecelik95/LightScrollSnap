using UnityEngine;
using UnityEngine.UI;

namespace LightScrollSnap
{
    [CreateAssetMenu(fileName = "FadeEffect", menuName = "ScrollSnapEffect/FadeEffect")]
    public class FadeEffect : BaseScrollSnapEffect
    {
        public float fadeAlpha = .45f;

        public override void OnItemUpdated(RectTransform transform, float displacement)
        {
            var graphics = transform.GetComponentsInChildren<Graphic>();
            var targetAlpha = fadeAlpha + (1 - fadeAlpha) * GetEffectRatioAbs(displacement);
            FadeGraphics(graphics, targetAlpha);
        }

        private void FadeGraphics(Graphic[] graphics, float alpha)
        {
            var length = graphics.Length;
            for (int i = 0; i < length; i++)
                Fade(graphics[i], alpha);
        }

        private void Fade(Graphic graphic, float alpha)
        {
            var color = graphic.color;
            var faded = color;
            faded.a = alpha;
            graphic.color = faded;
        }
    }
}