using System;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace RenderEngine.Shaders
{
    public class ShaderProgram
    {

        private int programID;
        private int vertexShaderID;
        private int fragmentShaderID;
        
        public ShaderProgram(String vertexFile, String fragmentFile)
        {

            this.vertexShaderID = loadShader(vertexFile, ShaderType.VertexShader); //apelam metoda de incarcare si salvam id-ul
            this.fragmentShaderID = loadShader(fragmentFile, ShaderType.FragmentShader);
            this.programID = GL.CreateProgram(); //creem programul
            GL.AttachShader(programID, vertexShaderID);
            GL.AttachShader(programID, fragmentShaderID); //atasam shaderele programului

            BindAttributes(); //metoda care linkeaza inputurile pentru shadere

            GL.LinkProgram(programID);  //creeaza executabile care vor fi rulate de procesorul grafic
            GL.ValidateProgram(programID); //valideaza daca s-au creat cum trebuie executabilele

            GetAllUniformLocations(); //sa ia de la bun inceput toate locatiile variabilelor uniforme
        }

        protected virtual void GetAllUniformLocations()
        {
            
        }
        //astea sunt daca nu vrem sa bindam la un anume VAO inputurile ci sa. bagam matricile noastre fara sa ne folosim de VAO
        protected int GetUniformLocation(String uniformName)
        {
            return GL.GetUniformLocation(programID, uniformName);   //cauta locatia din codul shaderului unde se afla o variabila cu un anumit nume dintr-un anume program
        }

        //in loc sa bindam la un atribut din VAO bagam direct valoarea pe care o vrem in inputul din vertex shader
        protected void LoadFloat(int location, float value)
        {
            GL.Uniform1(location, value);
        }

        protected void LoadInt(int location, int value)
        {
            GL.Uniform1(location, value);
        }

        protected void LoadVector(int location, Vector3 vector)
        {
            GL.Uniform3(location, vector.X, vector.Y, vector.Z);
        }

        protected void LoadBoolean(int location, bool value)
        {
            float toLoad = 0;
            if (value)
                toLoad = 1;

            GL.Uniform1(location, toLoad);
        }

        protected void LoadMatrix(int location, Matrix4 matrix)
        {
            GL.UniformMatrix4(location, false, ref matrix);
        }

        public void Start()
        {

            GL.UseProgram(programID);
        }

        public void Stop()
        {

            GL.UseProgram(0);
        }

        public void CleanUp()
        {

            Stop();
            GL.DetachShader(programID, vertexShaderID);
            GL.DetachShader(programID, fragmentShaderID);
            GL.DeleteShader(fragmentShaderID);
            GL.DeleteShader(vertexShaderID);
            GL.DeleteProgram(programID);
        }

        protected virtual void BindAttributes()
        {
            //metoda care linkeaza inputurile pentru shadere. ex pozitii.
            //(una din atributele VAO)
        }

        protected void bindAttribute(int attribute, String variableName)
        { //bindeaza un atribut la un anumit nume. gen positions

            GL.BindAttribLocation(programID, attribute, variableName); //bindeaza pentru programul ala un atribut la un nume

        }

        private static int loadShader(String file, ShaderType type)
        {

            //in shaderSource vom construi un string lung cu tot textul din fisierul shaderului. reader fiind obiect de citire a fisierului
            StringBuilder shaderSource = new StringBuilder();

            try
            {
                StreamReader shaderContent = new StreamReader(file);
                string line;
                while ((line = shaderContent.ReadLine()) != null)
                {
                    shaderSource.Append(line).Append("\n");
                }
                shaderContent.Close();

            }
            catch (IOException e)
            {
            }

            //creem un shader cu tipul trimis ca argument, atasam sursa id-ului respectiv, si il compilam
            int shaderID = GL.CreateShader(type);
            GL.ShaderSource(shaderID, shaderSource.ToString());
            GL.CompileShader(shaderID);

//            if (GL.GetShader(shaderID, ShaderParameter.CompileStatus) == GL_FALSE)
//            {
//                System.out.println(GL20.glGetShaderInfoLog(shaderID, 500));
//                System.err.println("Could not compile shader!");
//                System.exit(-1);
//            }
            //erori 

            //returnare de id
            return shaderID;


        }

    }
}