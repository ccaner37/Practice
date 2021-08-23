using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;

public class AddressablesManager : MonoBehaviour
{
    [SerializeField] Image image;

    [SerializeField]
    AssetReferenceGameObject assetReferenceGameObject;

    [SerializeField]
    AssetReference assetReferenceScene;

    [SerializeField]
    AssetReferenceSprite assetReferenceSprite;

    public void AddressablesPrefab()
    {
        Debug.Log("Load Addressables Prefab");
        Addressables.InstantiateAsync(assetReferenceGameObject);
    }

    public void AddressablesScene()
    {
        Debug.Log("Load Addressables Scene");
        assetReferenceScene.LoadSceneAsync(UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }

    public void AddressablesSprite()
    {
        Debug.Log("Load Addressables Sprite");
        assetReferenceSprite.LoadAssetAsync().Completed += OnSpriteLoaded;
    }

    private void OnSpriteLoaded(AsyncOperationHandle<Sprite> obj)
    {
        image.sprite = obj.Result;
    }
}
