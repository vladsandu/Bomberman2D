#version 400 core

in vec3 positions;
in vec2 textureCoords;

out vec2 pass_textureCoords;

uniform mat4 transformationMatrix;
uniform mat4 viewMatrix;

void main(void){

	vec4 worldPosition = transformationMatrix * vec4(positions.x,positions.y,positions.z,1.0);
	gl_Position = viewMatrix * worldPosition;
	
	pass_textureCoords = textureCoords;
}