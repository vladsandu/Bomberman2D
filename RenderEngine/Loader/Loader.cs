using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using RenderEngine.Entities;
using RenderEngine.Models;

namespace RenderEngine.Loader
{
    public class Loader
    {
        private readonly List<int> _vaos = new List<int>();//liste ca sa tinem cont de ele si sa le stergem
        private readonly List<int> _vbos = new List<int>();
        private readonly List<int> _textures = new List<int>();

        public RawModel LoadToVAO(float[] positions, float[] textureCoords, int[] indices,
            float widthPercent, float heightPercent)
        {
            int vaoID = CreateVAO();
            BindIndicesBuffer(indices); //bindam la VAO bufferul de indici automat.
            StoreDataInAttributeList(0, 3, positions);
            StoreDataInAttributeList(1, 2, textureCoords);
            UnbindVAO();

            return new RawModel(vaoID, indices.Length, widthPercent, heightPercent);  //un vertex are 3 floats (x,y,z)
        }

        public int LoadTexture(String filename)
        {

            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException(filename);

            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            // We will not upload mipmaps, so disable mipmapping (otherwise the texture will not appear).
            // We can use GL.GenerateMipmaps() or GL.Ext.GenerateMipmaps() to create
            // mipmaps automatically. In that case, use TextureMinFilter.LinearMipmapLinear to enable them.
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            
            Bitmap bmp = new Bitmap(filename);
            BitmapData bmp_data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp_data.Width, bmp_data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmp_data.Scan0);

            bmp.UnlockBits(bmp_data);

            return id;
        }

        private int CreateVAO()
        {

            int vaoID = GL.GenVertexArray(); //creeam
            _vaos.Add(vaoID);
            GL.BindVertexArray(vaoID);        //bindam
            return vaoID;                         //returnam

        }

        private void StoreDataInAttributeList(int attributeNumber, int coordinateSize, float[] data)
        {
            int vboID = GL.GenBuffer(); //acest vbo devine gl_array_buffer-ul. il bindam la el. el e un buffer oarecare.
            _vbos.Add(vboID);    //adaugam in lista pentru a-l putea sterge mai incolo
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID); //ca sa il putem folosi trebuie sa il bind-am
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(data.Length * sizeof(float)), data, BufferUsageHint.StaticDraw); //store into the VAO
            GL.VertexAttribPointer(attributeNumber, coordinateSize, VertexAttribPointerType.Float, false, 0, 0);  //penultimul 0 se refera daca. am si pozitia texturilor si alte lucruri. data vine gen: x0y0z0Texturax0Texturay0Texturaz0x1y1z1. in cazul asta distanta dintre 2 puncte este de alte 3 elemente.
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            //cand bindam un GL_ARRAY_BUFFER si dupa folosim glVertexAttribPointer, ceea ce e in array_buffer se va baga in VAO
        }

        public void CleanUp()
        {
            //dupa ce se inchide jocul le stergem
            for (int i = 0; i < _vaos.Count; i++)
                GL.DeleteVertexArray(i);

            for (int i = 0; i < _vbos.Count; i++)
                GL.DeleteBuffer(i);

            for (int i = 0; i < _textures.Count; i++)
                GL.DeleteTexture(i);
        }

        private void UnbindVAO()
        {
            
            GL.BindVertexArray(0);
        }

        private void BindIndicesBuffer(int[] indices)
        {
            int vboID = GL.GenBuffer();
            _vbos.Add(vboID);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, vboID);
            GL.BufferData(BufferTarget.ElementArrayBuffer,
                (IntPtr)(indices.Length * sizeof(float)), indices, BufferUsageHint.StaticDraw); //store into the VAO
            //nu trebuie debindat indicesbuffer. odata bindat. el se adauga automat la vao-ul activ. 
            //cand se debindeaza se detaseaza de la VAO
        }

        private IntPtr GetIntPtr(int[] data)
        {
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                return pointer;
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }
        }
  
//        public static Image[][] spriteSheetLoader(String filename, int rows, int cols, int width, int height)
//        {
//            //Aceasta functie incarca piesele din fisierul imaginiPiese in matricea de imagini
//
//            Image[][] spriteMatrix = null;
//           return spriteMatrix;
//    	}

	    public void ReloadVertices(Entity entity, float[] vertices)
        {
            RawModel rawModel = entity.Model.RawModel;

            GL.DeleteBuffer(_vbos.Count - 1); //implementare triviala

            GL.BindVertexArray(rawModel.VaoID);
            StoreDataInAttributeList(0, 3, vertices);

            UnbindVAO();
        } 
    }
}