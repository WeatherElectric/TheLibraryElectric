using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TheLibraryElectric.Misc
{
    public class RenderTextureLights : MonoBehaviour 
    {
        public RenderTexture renderTexture;
        public Light topLeftLight;
        public Light topRightLight;
        public Light bottomLeftLight;
        public Light bottomRightLight;
        public int samplingResolution = 5; // Resolution at which to sample the render texture
        public int updateInterval = 50; // Number of frames to wait before updating the lights


        private int frameCounter = 0;

        private void Update()
        {
            frameCounter++;
            if (frameCounter >= updateInterval)
            {
                frameCounter = 0;

                if (renderTexture == null || topLeftLight == null || topRightLight == null || bottomLeftLight == null || bottomRightLight == null)
                {
                    return;
                }

                // Read pixels from the render texture
                Texture2D tex = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
                RenderTexture.active = renderTexture;
                tex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
                tex.Apply();
                RenderTexture.active = null;

                Color[] cornerColors = GetCornerColors(tex);

                // Apply colors to lights
                topLeftLight.color = cornerColors[0];
                topRightLight.color = cornerColors[1];
                bottomLeftLight.color = cornerColors[2];
                bottomRightLight.color = cornerColors[3];
            }
        }

        Color[] GetCornerColors(Texture2D tex)
        {
            int width = tex.width;
            int height = tex.height;

            Color[] pixels = tex.GetPixels();

            // Define the regions for four corners
            Rect[] regions = new Rect[4];
            regions[0] = new Rect(0, 0, width / 2, height / 2); // Top left
            regions[1] = new Rect(width / 2, 0, width / 2, height / 2); // Top right
            regions[2] = new Rect(0, height / 2, width / 2, height / 2); // Bottom left
            regions[3] = new Rect(width / 2, height / 2, width / 2, height / 2); // Bottom right

            // Get the average color of each region
            Color[] cornerColors = new Color[4];
            for (int i = 0; i < 4; i++)
            {
                cornerColors[i] = GetAverageColor(tex, pixels, regions[i]);
            }

            return cornerColors;
        }

        Color GetAverageColor(Texture2D tex, Color[] pixels, Rect region)
        {
            int startX = Mathf.RoundToInt(region.x);
            int startY = Mathf.RoundToInt(region.y);
            int width = Mathf.RoundToInt(region.width);
            int height = Mathf.RoundToInt(region.height);

            // Calculate the average color within the region
            Color sumColor = Color.black;
            int pixelCount = 0;
            for (int y = startY; y < startY + height; y += samplingResolution)
            {
                for (int x = startX; x < startX + width; x += samplingResolution)
                {
                    Color pixelColor = pixels[y * tex.width + x];
                    sumColor += pixelColor;
                    pixelCount++;
                }
            }

            return sumColor / pixelCount;
        }
#if !UNITY_EDITOR
        public RenderTextureLights(IntPtr ptr) : base(ptr) { }
#endif

    }
}
