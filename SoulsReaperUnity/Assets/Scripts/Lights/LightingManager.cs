using UnityEngine;

public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;

    public float TimeOfDay;

    [SerializeField] private GameObject gManager;
    private float dayCd = 5f;

    private void Start()
    {
        dayCd = gManager.GetComponent<Phases>().phasesCd *2;
        TimeOfDay = dayCd/1.355f;
    }


    private void Update() 
    {
        if(Preset == null)
        {
            return;
        }
        
        if(Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= dayCd;
            UpdateLighting(TimeOfDay / dayCd);
        }
        else
        {
            UpdateLighting(TimeOfDay / dayCd);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);

        if(DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }

    private void OnValidate() 
    {
        if (DirectionalLight != null)
        {
            return;
        }

        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;

        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }

    } 

}
