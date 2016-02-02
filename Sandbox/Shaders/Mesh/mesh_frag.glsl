#version 330 core

in vec2 TexCoord;
in vec4 vertColour;

out vec4 colour;

uniform sampler2D inTexture;

void main()
{
    colour = vec4(1, 1, 1, 1); //texture(inTexture, TexCoord);
} 