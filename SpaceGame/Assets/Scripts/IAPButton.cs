using UnityEngine;
using System.Collections;

public class IAPButton : MonoBehaviour 
{
    public void Buy100()
    {
        IAPManager.Instance.Buy100Credits();
    }
    public void Buy200()
    {
        IAPManager.Instance.Buy200Credits();
    }
    public void Buy400()
    {
        IAPManager.Instance.Buy400Credits();
    }
    public void Buy1000()
    {
        IAPManager.Instance.Buy1000Credits();
    }
    public void Buy2000()
    {
        IAPManager.Instance.Buy2000Credits();
    }
    public void Buy5000()
    {
        IAPManager.Instance.Buy5000Credits();
    }
    public void Buy10000()
    {
        IAPManager.Instance.Buy10000Credits();
    }
    public void BuyNoAds()
    {
        IAPManager.Instance.BuyNoAds();
    }
}
