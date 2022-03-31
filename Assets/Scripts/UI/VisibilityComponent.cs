using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class VisibilityComponent : MonoBehaviour
{
    protected bool isFadingOut = false;
    public bool DestroyAfterFadeOut = false;
    protected void SetVisibility(CanvasGroup visibilityComp, bool isVisible)
    {
        /* 
        To change the appearance of a canvas element, CanvasGroup's alpha value is changed. 
        If the panel will be visible it directly appear, else it fades out slowly.
        */

        visibilityComp.interactable = isVisible;
        visibilityComp.blocksRaycasts = isVisible;

        if (isVisible)
        {
            visibilityComp.alpha = 1;
            isFadingOut = false;
            StopCoroutine(FadeOut());
        }
        else
        {
            if (isFadingOut)
                return;
            isFadingOut = true;
            StartCoroutine(FadeOut());
        }

        // Support Functions

        IEnumerator FadeOut()
        {
            for (float i = 1; i >= 0; i -= 0.035f)
            {
                visibilityComp.alpha = i;
                yield return new WaitForEndOfFrame();
            }
            isFadingOut = false;
            if (DestroyAfterFadeOut)
                Destroy(gameObject);
        }
    }
    protected void SetVisibility(List<SpriteRenderer> visibilityComps, bool isVisible)
    {
        /* 
        To change the appearance of a non-canvas element, SpriteRenderer.color's alpha value is changed. 
        If the panel will be visible it directly appear, else it fades out slowly.
        */

        if (isVisible)
        {
            SetRenderersAlpha(1);
            isFadingOut = false;
            StopCoroutine(FadeOut());
        }
        else
        {
            if (isFadingOut)
                return;
            isFadingOut = true;
            StartCoroutine(FadeOut());
        }

        // Support Functions

        IEnumerator FadeOut()
        {
            for (float i = 1; i >= 0; i -= 0.005f)
            {
                SetRenderersAlpha(i);
                yield return new WaitForEndOfFrame();
            }
            isFadingOut = false;
            if (DestroyAfterFadeOut)
                Destroy(gameObject);
        }
        void SetRenderersAlpha(float newAlpha)
        {
            Color tmp;
            foreach (SpriteRenderer visibilityComp in visibilityComps)
            {
                tmp = visibilityComp.color;
                tmp.a = newAlpha;
                visibilityComp.color = tmp;
            }
        }
    }
}
