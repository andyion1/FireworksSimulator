using DrawingLibrary.Graphics;
using DrawingLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Graphics
{
    public class Screen : IScreen
    {
        private readonly RenderTarget2D _renderTarget;
        private GraphicsDevice _graphicsDevice;

        private bool _isRenderTargetSet = false;

        private readonly int _width;
        private readonly int _height;

        public Screen(RenderTarget2D renderTarget)
        {
            _renderTarget = renderTarget;
            _graphicsDevice = renderTarget.GraphicsDevice;
            _height = _renderTarget.Height;
            _width = _renderTarget.Width;
        }

        // expose screen dimensions
        public int Height => _height;
        public int Width => _width;

        // draws the render target content onto the window
        public void Present(ISpritesRenderer spritesRenderer, bool textureFiltering = true)
        {
            if (spritesRenderer == null)
            {
                throw new ArgumentNullException(nameof(spritesRenderer));
            }

            spritesRenderer.Begin(textureFiltering);
            Rectangle destinationRectangle = CalculateDestinationRectangle();
            spritesRenderer.Draw(_renderTarget, destinationRectangle, Color.White);
            spritesRenderer.End();
        }

        // keeps the aspect ratio when resizing window
        public Rectangle CalculateDestinationRectangle()
        {
            int windowWidth = _graphicsDevice.Viewport.Width;
            int windowHeight = _graphicsDevice.Viewport.Height;

            float screenAspectRatio = (float)_width / _height;
            float windowAspectRatio = (float)windowWidth / windowHeight;

            int destinationWidth;
            int destinationHeight;

            int sX = 0;
            int sY = 0;

            if (windowAspectRatio > screenAspectRatio)
            {
                destinationHeight = windowHeight;
                destinationWidth = (int)(destinationHeight * screenAspectRatio);
                sX = (windowWidth - destinationWidth) / 2;
            }
            else
            {
                destinationWidth = windowWidth;
                destinationHeight = (int)(destinationWidth / screenAspectRatio);
                sY = (windowHeight - destinationHeight) / 2;
            }

            return new Rectangle(sX, sY, destinationWidth, destinationHeight);
        }

        // activates this render target for drawing
        public void Set()
        {
            if (_isRenderTargetSet)
            {
                throw new Exception("Render target is already set.");
            }

            _graphicsDevice.SetRenderTarget(_renderTarget);
            _isRenderTargetSet = true;
        }

        // unbinds the render target
        public void UnSet()
        {
            if (!_isRenderTargetSet)
            {
                throw new Exception("Render target is already unset.");
            }

            _graphicsDevice.SetRenderTarget(null);
            _isRenderTargetSet = false;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
