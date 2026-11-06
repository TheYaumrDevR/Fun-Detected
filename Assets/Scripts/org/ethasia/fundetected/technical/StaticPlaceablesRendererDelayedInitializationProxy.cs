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

        public void RenderTombstone(string id, float posX, float posY)
        {
            if (null != renderer)
            {
                renderer.RenderTombstone(id, posX, posY);
                return;
            }

            pendingActions.Add(r => r.RenderTombstone(id, posX, posY));
        }

        public void MoveTombstoneVertically(string id, float units)
        {
            if (null != renderer)
            {
                renderer.MoveTombstoneVertically(id, units);
                return;
            }

            pendingActions.Add(r => r.MoveTombstoneVertically(id, units));
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