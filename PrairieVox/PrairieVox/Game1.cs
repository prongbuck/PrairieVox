using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PrairieVox
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera camera;
        
        VertexPositionColor[] verts;
        VertexBuffer vertexBuffer;
        BasicEffect effect;

        int[,,] blocks;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Initialize camera
            camera = new Camera(this, new Vector3(32, 32, 150), new Vector3(32, 32, 0), Vector3.Up);
            Components.Add(camera);

            blocks = new int[32, 32, 32];

            for (int x = 0; x < 32; x++)
                for (int y = 0; y < 32; y++)
                    for (int z = 0; z < 32; z++)
                        blocks[x, y, z] = 1;

                base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            verts = new VertexPositionColor[36];

            // Initialize vertices
            // front
            verts[0] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Blue);
            verts[1] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Red);
            verts[2] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Green);
            verts[3] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Orange);
            verts[4] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Blue);
            verts[5] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Green);

            // back
            verts[6] = new VertexPositionColor(new Vector3(-1, 1, -3), Color.Green);
            verts[7] = new VertexPositionColor(new Vector3(1, -1, -3), Color.Blue);
            verts[8] = new VertexPositionColor(new Vector3(1, 1, -3), Color.Orange);
            verts[9] = new VertexPositionColor(new Vector3(-1, 1, -3), Color.Green);
            verts[10] = new VertexPositionColor(new Vector3(-1, -1, -3), Color.Red);
            verts[11] = new VertexPositionColor(new Vector3(1, -1, -3), Color.Blue);

            //top
            verts[12] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Green);
            verts[13] = new VertexPositionColor(new Vector3(-1, 1, -3), Color.Red);
            verts[14] = new VertexPositionColor(new Vector3(1, 1, -3), Color.Blue);
            verts[15] = new VertexPositionColor(new Vector3(1, 1, -3), Color.Blue);
            verts[16] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Orange);
            verts[17] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Green);

            //bottom
            verts[18] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Green);
            verts[19] = new VertexPositionColor(new Vector3(-1, -1, -3), Color.Orange);
            verts[20] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Blue);
            verts[21] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Blue);
            verts[22] = new VertexPositionColor(new Vector3(1, -1, -3), Color.Red);
            verts[23] = new VertexPositionColor(new Vector3(-1, -1, -3), Color.Green);

            //right
            verts[24] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Green);
            verts[25] = new VertexPositionColor(new Vector3(1, 1, -3), Color.Orange);
            verts[26] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Blue);
            verts[27] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Blue);
            verts[28] = new VertexPositionColor(new Vector3(1, 1, -3), Color.Red);
            verts[29] = new VertexPositionColor(new Vector3(1, -1, -3), Color.Green);

            // left
            verts[30] = new VertexPositionColor(new Vector3(-1, 1, -3), Color.Green);
            verts[31] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Red);
            verts[32] = new VertexPositionColor(new Vector3(-1, -1, -3), Color.Blue);
            verts[33] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Blue);
            verts[34] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Orange);
            verts[35] = new VertexPositionColor(new Vector3(-1, -1, -3), Color.Green);
            
            // Set vertex data in VertexBuffer            
            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor),
            verts.Length, BufferUsage.None);
            vertexBuffer.SetData(verts);

            // Initialize the BasicEffect
            effect = new BasicEffect(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            GraphicsDevice.SetVertexBuffer(vertexBuffer);

            // turn on wireframe mode
            RasterizerState rs = new RasterizerState();
            rs.FillMode = FillMode.WireFrame;
            GraphicsDevice.RasterizerState = rs;
            
            ////Set object and camera info
            //effect.World = Matrix.Identity;
            //effect.View = camera.view;
            //effect.Projection = camera.projection;
            //effect.VertexColorEnabled = true;
            //// Begin effect and draw for each pass           

            //foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            //{
            //    pass.Apply();
            //    GraphicsDevice.DrawUserPrimitives<VertexPositionColor>
            //    (PrimitiveType.TriangleList, verts, 0, 12);
            //}

            //Set object and camera info            
            effect.View = camera.view;
            effect.Projection = camera.projection;
            effect.VertexColorEnabled = false;

            for (int x = 0; x < 32; x++)
                for (int y = 0; y < 32; y++)
                    for (int z = 0; z < 32; z++)
                    {
                        effect.World = Matrix.Identity;
                        effect.World *= Matrix.CreateTranslation(new Vector3(x * 2, y * 2, z * 2));

                        // Begin effect and draw for each pass                       
                        foreach (EffectPass pass in effect.CurrentTechnique.Passes)
                        {
                            pass.Apply();
                            GraphicsDevice.DrawUserPrimitives<VertexPositionColor>
                            (PrimitiveType.TriangleList, verts, 0, 12);
                        }
                    }

            base.Draw(gameTime);
        }
    }
}
