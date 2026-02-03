using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class Health : MonoBehaviour
{
    private bool healthSnapshotActive = false;

    private EventInstance heartbeatInstance;
    public EventReference heartbeatEvent;

    private EventInstance healthSnapshotInstance;
    public EventReference healthSnapshot;

    void Start()
    {
        // Создаём heartbeat один раз и запускаем, он всегда играет
        if (!heartbeatEvent.IsNull)
        {
            heartbeatInstance = RuntimeManager.CreateInstance(heartbeatEvent);
            heartbeatInstance.start();
            heartbeatInstance.setParameterByNameWithLabel("low_health", "Normal");
        }
        else
        {
            Debug.LogError("Heartbeat Event не назначен!");
        }

        // Создаём snapshot один раз, но не запускаем
        if (!healthSnapshot.IsNull)
        {
            healthSnapshotInstance = RuntimeManager.CreateInstance(healthSnapshot);
        }
        else
        {
            Debug.LogError("Health Snapshot Event не назначен!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            healthSnapshotActive = !healthSnapshotActive;
            ToggleHealthState(healthSnapshotActive);
        }
    }

    private void ToggleHealthState(bool activate)
    {
        // Snapshot включаем/выключаем, но heartbeat **не трогаем**
        if (healthSnapshotInstance.isValid())
        {
            if (activate)
            {
                healthSnapshotInstance.start();
                heartbeatInstance.start();
            }
            else
            {
                healthSnapshotInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                heartbeatInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
        }

        // Меняем параметр heartbeat, чтобы он реагировал на состояние
        if (heartbeatInstance.isValid())
        {
            heartbeatInstance.setParameterByNameWithLabel("low_health", activate ? "Low" : "Normal");

        }
    }

    private void OnDestroy()
    {
        if (heartbeatInstance.isValid())
        {
            heartbeatInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            heartbeatInstance.release();
        }

        if (healthSnapshotInstance.isValid())
        {
            healthSnapshotInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            healthSnapshotInstance.release();
        }
    }
}