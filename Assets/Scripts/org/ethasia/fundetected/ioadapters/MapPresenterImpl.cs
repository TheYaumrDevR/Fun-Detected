using System;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class MapPresenterImpl : IMapPresenter
    {
        private ITileMapRenderer tileMapRenderer;
        private IPortalRenderer portalRenderer;
        private IInteractablesRenderer interactablesRenderer;
        private Dictionary<string, Action<TileRenderContext>> renderMethodByTileLayerName;

        public MapPresenterImpl()
        {
            portalRenderer = TechnicalFactory.GetInstance().GetPortalRendererInstance();
            tileMapRenderer = TechnicalFactory.GetInstance().GetTileMapRendererInstance();
            interactablesRenderer = TechnicalFactory.GetInstance().GetInteractablesRendererInstance();
            renderMethodByTileLayerName = new Dictionary<string, Action<TileRenderContext>>();

            renderMethodByTileLayerName.Add("ground", tileMapRenderer.RenderGroundTileAtPosition);
            renderMethodByTileLayerName.Add("foliageBack", tileMapRenderer.RenderFoliageBackTileAtPosition);
            renderMethodByTileLayerName.Add("foliageFront", tileMapRenderer.RenderFoliageFrontTileAtPosition);
            renderMethodByTileLayerName.Add("terrain", tileMapRenderer.RenderTerrainTileAtPosition);
        }

        public void PresentTiles(List<ITile> tilesWithAbsolutePositions, string tileMapName)
        {   
            foreach (ITile tile in tilesWithAbsolutePositions)
            {
                for (int i = tile.StartX; i < tile.StartX + tile.Width; i++)
                {
                    for (int j = tile.StartY; j < tile.StartY + tile.Height; j++)
                    {
                        if (renderMethodByTileLayerName.ContainsKey(tileMapName))
                        {
                            string tileSetName = tile.Id.Substring(0, tile.Id.LastIndexOf("_"));

                            TileRenderContext tileRenderContext = new TileRenderContext.Builder()
                                .SetTileSetName(tileSetName)
                                .SetTileName(tile.Id)
                                .SetX(i)
                                .SetY(j)
                                .Build();

                            renderMethodByTileLayerName[tileMapName](tileRenderContext);
                        }
                    }
                }
            }
        }

        public void PresentPortal(MapPortal portal)
        {
            float engineWidth = portal.Width * 0.1f;
            float engineHeight = portal.Height * 0.1f;

            float engineX = portal.Position.X * 0.1f;
            float engineY = portal.Position.Y * 0.1f;

            if (0 == portal.Width % 2)
            {
                engineX += 0.1f;
            }
            else
            {
                engineX += 0.05f;
            }

            if (0 == portal.Height % 2)
            {
                engineY += 0.1f;
            }
            else
            {
                engineY += 0.05f;
            }

            SingleColorRectangularRenderShapeProxy portalRenderShape = new SingleColorRectangularRenderShapeProxy.Builder()
                .SetX(engineX)
                .SetY(engineY)
                .SetWidth(engineWidth)
                .SetHeight(engineHeight)
                .SetLabel(portal.DestinationMapId)
                .Build();

            portalRenderer.RenderPortal(portalRenderShape);
        }

        public void PresentHealingWell(HealingWell healingWell)
        {
            float engineX = healingWell.Position.X * 0.1f;
            float engineY = healingWell.Position.Y * 0.1f;

            InteractableRenderProxy healingWellRenderProxy = new InteractableRenderProxy.Builder()
                .SetRenderImageName("healingWell")
                .SetInteractableDisplayName("Healing Well")
                .SetPosX(engineX)
                .SetPosY(engineY)
                .Build();

            interactablesRenderer.RenderInteractable(healingWellRenderProxy);
        }

        public void PresentEmpty()
        {
            portalRenderer.ClearRenderedPortals();
            interactablesRenderer.ClearRenderedInteractables();
            tileMapRenderer.ClearAllTiles();
        }
    }
}