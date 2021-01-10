using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SampleShader : MonoBehaviour
{
    [SerializeField] ComputeShader shader;
    public RenderTexture result;

    [Range(-1,1)] public float brightness = 0;

    // Start is called before the first frame update
    void Start() {
        int kernel = shader.FindKernel("CSMain");

        result = new RenderTexture(512, 512, 24);
        result.enableRandomWrite = true;
        result.Create();

        shader.SetFloat("resolution", result.width);
        shader.SetFloat("brightness", brightness);
        shader.SetTexture(kernel, "Result", result);
        shader.Dispatch(kernel, 512 / 8, 512 / 8, 1);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (result == null)
        {
            result = new RenderTexture(512, 512, 24);
            result.enableRandomWrite = true;
            result.Create();
        }

        shader.SetTexture(shader.FindKernel("CSMain"), "Result", result);
        shader.SetFloat("brightness", brightness);
        shader.Dispatch(shader.FindKernel("CSMain"), 512 / 8, 512 / 8, 1);

        Graphics.Blit(result, destination);
    }
}
