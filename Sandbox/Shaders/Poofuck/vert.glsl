#version 330 core
  
layout (location = 0) in vec3 position;
layout (location = 1) in vec3 colour;
layout (location = 2) in vec3 TexCoord;

out vec4 vertColour;

void main()
{
    gl_Position = vec4(position.x, position.y, position.z, 1.0);
	vertColour = vec4(colour, 1.0);
}