using System;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class StaticPlaceablesRendererDelayedInitializationProxy : IStaticPlaceablesRenderer
    {
        private IStaticPlaceablesRenderer renderer;
        private List<Action<IStaticPlaceablesRenderer>> pendingActions = new List<Action<IStaticPlaceablesRenderer>>();

        public StaticPlaceablesRendererDelayedInitializationProxy()
        {
            renderer = StaticPlaceablesRenderer.GetInstance();

            if (null == renderer)
            {
                StaticPlaceablesRenderer.RegisterProxy(this);
            }
        }

        public void OnStaticPlaceablesRendererAwake(IStaticPlaceablesRenderer awakenedRenderer)
        {
            renderer = awakenedRenderer;

            foreach (Action<IStaticPlaceablesRenderer> action in pendingActions)
            {
                action(renderer);
            }

            pendingActions.Clear();
        }

        public void RenderTombstone(float posX, float posY)
        {
            if (null != renderer)
            {
                renderer.RenderTombstone(posX, posY);
                return;
            }

            pendingActions.Add(renderer => renderer.RenderTombstone(posX, posY));
        }

        public void ClearRenderedStaticPlaceables()
        {
            if (null != renderer)
            {
                renderer.ClearRenderedStaticPlaceables();
                return;
            }

            pendingActions.Clear();
        }
    }
}