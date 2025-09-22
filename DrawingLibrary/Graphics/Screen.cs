using DrawingLib.Graphics;
using DrawingLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary
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

        public int Height => _height;

        public int Width => _width;

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

        public void Set()
        {
            if (_isRenderTargetSet)
            {
                throw new Exception("Render target is already set.");
            }

            _graphicsDevice.SetRenderTarget(_renderTarget);
            _isRenderTargetSet = true;
        }


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
