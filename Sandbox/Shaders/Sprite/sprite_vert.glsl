#version 330 core
  
layout (location = 0) in vec3 position;
layout (location = 1) in vec3 colour;
layout (location = 2) in vec2 texCoord;

uniform mat4 transform;
uniform mat4 projection;
out vec4 vertColour;

out vec2 TexCoord;

void main()
{
    gl_Position = projection * transform * vec4(position.x, position.y, position.z, 1.0);

	vertColour = vec4(colour, 1.0);

	TexCoord = texCoord;
}