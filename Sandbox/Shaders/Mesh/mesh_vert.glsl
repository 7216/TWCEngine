#version 330 core
  
layout (location = 0) in vec3 position;
layout (location = 1) in vec3 normal;
layout (location = 2) in vec2 texCoord;

uniform mat4 transform;
out vec4 vertColour;

out vec2 TexCoord;

void main()
{
    gl_Position = transform * vec4(position, 1.0);

	vertColour = vec4(normal.x, normal.y, normal.z, 1.0);

	TexCoord = texCoord;
}