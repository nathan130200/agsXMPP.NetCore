namespace agsXMPP.protocol.iq.jingle;

using Xml.Dom;

public class Jingle : Element
{
    public Jingle()
    {
        TagName = "jingle";
        Namespace	= Namespaces.IQ_JINGLE1;
    }
    
}