namespace agsXMPP.protocol.x.muc.iq;

using Xml.Dom;

public class Unique:Element
{
    public Unique()
    {
        TagName = "unique";
        Namespace = Namespaces.MUC_UNIQUE;
    }
}