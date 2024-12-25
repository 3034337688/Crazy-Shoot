using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameMei
{
    public static class UIExtension
    {
        //UI的淡入淡出动画的效果
        public static IEnumerator FadeToAlpha(this CanvasGroup canvasGroup,float alpha,float duration)
        {
            float timer = 0.0f;
            float originalAlpha = canvasGroup.alpha;
            while(timer<duration)
            {
                timer += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(originalAlpha, alpha, timer / duration);
                yield return new WaitForEndOfFrame();
            }

            canvasGroup.alpha = alpha;
        }
    }
}
