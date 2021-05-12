using UnityEngine;

/// <summary>
/// Singleton object for global game code.
/// </summary>
public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    private CollectibleSystem collectibleSystem;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("A \'Game\' singleton instance already exists!");
            return;
        }

        // Initialization
        Instance = this;
        this.collectibleSystem = new CollectibleSystem();
    }

    public CollectibleSystem GetCollectibleSystem()
    {
        return this.collectibleSystem;
    }
}