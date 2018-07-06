using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.Purchasing;


// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
public class IAPManager : MonoBehaviour, IStoreListener
{
    public static IAPManager Instance{ set; get; }

    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.


    public static string PRODUCT_100_CREDITS =    "credit1";   
    public static string PRODUCT_200_CREDITS =    "credit2";   
    public static string PRODUCT_400_CREDITS =    "credit3";   
    public static string PRODUCT_1000_CREDITS =    "credit4";   
    public static string PRODUCT_2000_CREDITS =    "credit5";   
    public static string PRODUCT_5000_CREDITS =    "credit6";   
    public static string PRODUCT_10000_CREDITS =    "credit7";
    public static string PRODUCT_NO_ADS =  "noads"; 

    private float creditText;
    private float creditTemp;
    private float creditMainTemp;
    private float creditMain;

    private void Awake()
    {
        Instance = this;
         }
    void Start()
    {
        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null)
        {
            // Begin to configure our connection to Purchasing
            InitializePurchasing();
        }
    }
    private void Update()
    {
    }
    public void InitializePurchasing() 
    {
        // If we have already connected to Purchasing ...
        if (IsInitialized())
        {
            // ... we are done here.
            return;
        }

        // Create a builder, first passing in a suite of Unity provided stores.
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(PRODUCT_100_CREDITS, ProductType.Consumable);
        builder.AddProduct(PRODUCT_200_CREDITS, ProductType.Consumable);
        builder.AddProduct(PRODUCT_400_CREDITS, ProductType.Consumable);
        builder.AddProduct(PRODUCT_1000_CREDITS, ProductType.Consumable);
        builder.AddProduct(PRODUCT_2000_CREDITS, ProductType.Consumable);
        builder.AddProduct(PRODUCT_5000_CREDITS, ProductType.Consumable);
        builder.AddProduct(PRODUCT_10000_CREDITS, ProductType.Consumable);
        builder.AddProduct(PRODUCT_NO_ADS, ProductType.NonConsumable);


        UnityPurchasing.Initialize(this, builder);
         }
    private bool IsInitialized()
    {
        // Only say we are initialized if both the Purchasing references are set.
        return m_StoreController != null && m_StoreExtensionProvider != null;
         }
    public void Buy100Credits()
    {
        BuyProductID(PRODUCT_100_CREDITS);
         }
    public void Buy200Credits()
    {
        BuyProductID(PRODUCT_200_CREDITS);
    }
    public void Buy400Credits()
    {
        BuyProductID(PRODUCT_400_CREDITS);
    }
    public void Buy1000Credits()
    {
        BuyProductID(PRODUCT_1000_CREDITS);
    }
    public void Buy2000Credits()
    {
        BuyProductID(PRODUCT_2000_CREDITS);
         }
    public void Buy5000Credits()
    {
        BuyProductID(PRODUCT_5000_CREDITS);
         }
    public void Buy10000Credits()
    {
        BuyProductID(PRODUCT_10000_CREDITS);
         }
    public void BuyNoAds()
    {
        BuyProductID(PRODUCT_NO_ADS);
         }
    private void BuyProductID(string productId)
    {
        // If Purchasing has been initialized ...
        if (IsInitialized())
        {
            // ... look up the Product reference with the general product identifier and the Purchasing 
            // system's products collection.
            Product product = m_StoreController.products.WithID(productId);

            // If the look up found a product for this device's store and that product is ready to be sold ... 
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                // asynchronously.
                m_StoreController.InitiatePurchase(product);
            }
            // Otherwise ...
            else
            {
                // ... report the product look-up failure situation  
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        // Otherwise ...
        else
        {
            // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
            // retrying initiailization.
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
         }

    // Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
    // Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
    public void RestorePurchases()
    {
        // If Purchasing has not yet been set up ...
        if (!IsInitialized())
        {
            // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        // If we are running on an Apple device ... 
        if (Application.platform == RuntimePlatform.IPhonePlayer || 
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            // ... begin restoring purchases
            Debug.Log("RestorePurchases started ...");

            // Fetch the Apple store-specific subsystem.
            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            // Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
            // the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
            apple.RestoreTransactions((result) => {
                // The first phase of restoration. If no more responses are received on ProcessPurchase then 
                // no purchases are available to be restored.
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        // Otherwise ...
        else
        {
            // We are not running on an Apple device. No work is necessary to restore purchases.
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
         }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        // Purchasing has succeeded initializing. Collect our Purchasing references.
        Debug.Log("OnInitialized: PASS");

        // Overall Purchasing system, configured with products for this application.
        m_StoreController = controller;
        // Store specific subsystem, for accessing device-specific store features.
        m_StoreExtensionProvider = extensions;
         }
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
         }
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) 
    {
        if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_100_CREDITS, StringComparison.Ordinal))
        {
            Debug.Log("You've just bought 100 Credits");
            PlayerPrefs.SetFloat("IAPCredit", 100);
            creditTemp = (int)PlayerPrefs.GetFloat("Credit");
            creditMainTemp = PlayerPrefs.GetFloat("IAPCredit");
            creditMain = creditMainTemp + creditTemp;
            PlayerPrefs.SetFloat("Credit", creditMain);
            PlayerPrefs.SetFloat("IAPCredit", 0);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_200_CREDITS, StringComparison.Ordinal))
        {
            Debug.Log("You've just bought 200 Credits");
            PlayerPrefs.SetFloat("IAPCredit", 200);
            creditTemp = (int)PlayerPrefs.GetFloat("Credit");
            creditMainTemp = PlayerPrefs.GetFloat("IAPCredit");
            creditMain = creditMainTemp + creditTemp;
            PlayerPrefs.SetFloat("Credit", creditMain);
            PlayerPrefs.SetFloat("IAPCredit", 0);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_400_CREDITS, StringComparison.Ordinal))
        {
            Debug.Log("You've just bought 400 Credits");
            PlayerPrefs.SetFloat("IAPCredit", 500);
            creditTemp = (int)PlayerPrefs.GetFloat("Credit");
            creditMainTemp = PlayerPrefs.GetFloat("IAPCredit");
            creditMain = creditMainTemp + creditTemp;
            PlayerPrefs.SetFloat("Credit", creditMain);
            PlayerPrefs.SetFloat("IAPCredit", 0);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_1000_CREDITS, StringComparison.Ordinal))
        {
            Debug.Log("You've just bought 1000 Credits");
            PlayerPrefs.SetFloat("IAPCredit", 1000);
            creditTemp = (int)PlayerPrefs.GetFloat("Credit");
            creditMainTemp = PlayerPrefs.GetFloat("IAPCredit");
            creditMain = creditMainTemp + creditTemp;
            PlayerPrefs.SetFloat("Credit", creditMain);
            PlayerPrefs.SetFloat("IAPCredit", 0);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_2000_CREDITS, StringComparison.Ordinal))
        {
            Debug.Log("You've just bought 2000 Credits");
            PlayerPrefs.SetFloat("IAPCredit", 2000);
            creditTemp = (int)PlayerPrefs.GetFloat("Credit");
            creditMainTemp = PlayerPrefs.GetFloat("IAPCredit");
            creditMain = creditMainTemp + creditTemp;
            PlayerPrefs.SetFloat("Credit", creditMain);
            PlayerPrefs.SetFloat("IAPCredit", 0);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_5000_CREDITS, StringComparison.Ordinal))
        {
            Debug.Log("You've just bought 5000 Credits");
            PlayerPrefs.SetFloat("IAPCredit", 5000);
            creditTemp = (int)PlayerPrefs.GetFloat("Credit");
            creditMainTemp = PlayerPrefs.GetFloat("IAPCredit");
            creditMain = creditMainTemp + creditTemp;
            PlayerPrefs.SetFloat("Credit", creditMain);
            PlayerPrefs.SetFloat("IAPCredit", 0);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_10000_CREDITS, StringComparison.Ordinal))
        {
            Debug.Log("You've just bought 10000 Credits");
            PlayerPrefs.SetFloat("IAPCredit", 10000);
            creditTemp = (int)PlayerPrefs.GetFloat("Credit");
            creditMainTemp = PlayerPrefs.GetFloat("IAPCredit");
            creditMain = creditMainTemp + creditTemp;
            PlayerPrefs.SetFloat("Credit", creditMain);
            PlayerPrefs.SetFloat("IAPCredit", 0);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_NO_ADS, StringComparison.Ordinal))
        {
            Debug.Log("No ads");
        }
        else 
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }

        return PurchaseProcessingResult.Complete;
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}
