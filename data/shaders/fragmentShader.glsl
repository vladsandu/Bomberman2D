#version 400 core

in vec2 pass_textureCoords;

out vec4 out_Colours;

uniform sampler2D textureSampler;
uniform float xOffset;
uniform float yOffset;

void main(void){	
	vec2 final_textureCoords;
	
	final_textureCoords.x = pass_textureCoords.x + xOffset;
	final_textureCoords.y = pass_textureCoords.y + yOffset;
	
	vec4 pixelColour = texture(textureSampler,final_textureCoords);

	if(pixelColour.a < 0.5){
		discard;
	}

	out_Colours = pixelColour; 
}