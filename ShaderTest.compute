// Each #kernel tells which function to compile; you can have many kernels
#pragma kernel CSMain

RWTexture2D<float4> Result;
float resolution;
float brightness;

[numthreads(8,8,1)]
void CSMain (uint3 id : SV_DispatchThreadID)
{
    float x = id.x/resolution + brightness;
    float y = id.y/resolution + brightness;

    Result[id.xy] = float4(x, y, 0, 0.0);
}
