using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] Button m_RewardedButton_EnabledBy_OnUnityAdsReady;
    private string placementId = "rewardedVideo";

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize("19538");
    }

    public void OnClick_ShowRewarded()
    {
        if(Advertisement.IsReady(placementId))
        {
            Debug.Log("iOS_Rewarded placement is ready");

            Advertisement.Show(placementId);
        }
        else
        {
            Debug.Log("rewarded placement not ready");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("placement ready : " + placementId);

        if(placementId == placementId)
        {
            m_RewardedButton_EnabledBy_OnUnityAdsReady.interactable = true;
        }
    }

   
    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("OnUnityAdsDidStart " + placementId);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Debug.Log("OnUnityAdsDidFinish " + placementId + " " +  showResult.ToString());
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }
}
