namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public interface IAffixVisitor
    {
        void Visit(IAffixWithOneFloat affix);
        void Visit(IAffixWithOneInteger affix);
        void Visit(IAffixWithTwoIntegers affix);
    }
}