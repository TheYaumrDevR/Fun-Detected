using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Ioadapters.Presentation.UI;

namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public struct ItemTooltipRenderContext
    {
        public string ItemName
        {
            get;
            private set;
        }

        public string ItemBaseTypeName
        {
            get;
            private set;
        }

        public ItemPotential ItemPotential
        {
            get;
            private set;
        }

        public List<List<UiTextSegment>> ItemHeaderLines
        {
            get;
            private set;
        }

        public List<List<UiTextSegment>> ItemImplicitLines
        {
            get;
            private set;
        }

        public List<List<UiTextSegment>> ItemExplicitLines
        {
            get;
            private set;
        }

        public class Builder
        {
            private ItemTooltipRenderContext result;

            public Builder WithItemName(string value)
            {
                result.ItemName = value;
                return this;
            }

            public Builder WithItemBaseTypeName(string value)
            {
                result.ItemBaseTypeName = value;
                return this;
            }

            public Builder WithItemPotential(ItemPotential value)
            {
                result.ItemPotential = value;
                return this;
            }

            public Builder WithItemHeaderLines(List<List<UiTextSegment>> value)
            {
                result.ItemHeaderLines = value;
                return this;
            }

            public Builder WithItemImplicitLines(List<List<UiTextSegment>> value)
            {
                result.ItemImplicitLines = value;
                return this;
            }

            public Builder WithItemExplicitLines(List<List<UiTextSegment>> value)
            {
                result.ItemExplicitLines = value;
                return this;
            }

            public ItemTooltipRenderContext Build()
            {
                return result;
            }
        }
    }
}