using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PushRateBarUI : MonoBehaviour 
{
    public RectTransform IndicatorRectTransform;
    public Image IndicatorImage;
    public Color BelowPushRateColor;
    public Color WithinPushRateColor;
    public Color AbovePushRateColor;

    private float minWidth;
    private float maxWidth;

	void Start () 
    {
        minWidth = 0.0f;
        maxWidth = IndicatorRectTransform.rect.width;
        IndicatorRectTransform.sizeDelta = new Vector2(minWidth, IndicatorRectTransform.rect.height);
        IndicatorImage.color = BelowPushRateColor;
	}

    public void UpdateIndicator(PushRateTracker tracker) 
    {
        float pushRate = tracker.GetCurrentPushRate();
        if (pushRate <= tracker.maximumPushRate)
        {
            float percentage = (pushRate * 100) / tracker.maximumPushRate;
            float amountToApply = maxWidth * (percentage / 100);
            IndicatorRectTransform.sizeDelta = new Vector2(amountToApply, IndicatorRectTransform.rect.height);
        }
        else if (pushRate >= tracker.maximumPushRate)
        {
            IndicatorRectTransform.sizeDelta = new Vector2(maxWidth, IndicatorRectTransform.rect.height);
        }
        UpdateBarColor(tracker);
	}

    private void UpdateBarColor(PushRateTracker tracker)
    {
        float minPercentage = (tracker.perfectRateMinimum * 100) / tracker.maximumPushRate;
        float minimumPerfectRateWidth = maxWidth * (minPercentage / 100);

        float maxPercentage = (tracker.perfectRateMaximum * 100) / tracker.maximumPushRate;
        float maximumPerfectRateWidth = maxWidth * (maxPercentage / 100);

        if (IndicatorRectTransform.sizeDelta.x < minimumPerfectRateWidth)
        {
            IndicatorImage.color = BelowPushRateColor;
        }
        else if (IndicatorRectTransform.sizeDelta.x >= minimumPerfectRateWidth && IndicatorRectTransform.sizeDelta.x <= maximumPerfectRateWidth)
        {
            IndicatorImage.color = WithinPushRateColor;
        }
        else if (IndicatorRectTransform.sizeDelta.x > maximumPerfectRateWidth)
        {
            IndicatorImage.color = AbovePushRateColor;
        }
    }

    public void ResetBar()
    {
        IndicatorRectTransform.sizeDelta = new Vector2(minWidth, IndicatorRectTransform.rect.height);
    }
}
