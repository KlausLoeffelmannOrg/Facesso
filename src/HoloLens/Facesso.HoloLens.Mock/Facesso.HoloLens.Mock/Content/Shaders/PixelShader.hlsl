Texture2D ShaderTexture : register(t0);
SamplerState Sampler : register(s0);

// Per-pixel color data passed through the pixel shader.
struct PixelShaderInput
{
    min16float4 pos   : SV_POSITION;
	float2 TextureUV : TEXCOORD0;
};

// The pixel shader passes through the color data. The color data from 
// is interpolated and assigned to a pixel at the rasterization step.
float4 main(PixelShaderInput input) : SV_TARGET
{
	return ShaderTexture.Sample(Sampler, input.TextureUV);
}
