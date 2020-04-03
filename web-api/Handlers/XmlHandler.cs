using models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace web_api.Handlers {
  public class XmlHandler {

    public XmlHandler() {

    }

    // Funcion convierte un objeto a Xml
    public XmlDocument ToXml(Venta ven) {

      XmlDocument doc = new XmlDocument();
      XmlElement raiz = doc.CreateElement("Ventas");
      doc.AppendChild(raiz);

      XmlElement venta = doc.CreateElement("Venta");
      raiz.AppendChild(venta);

      XmlElement Id = doc.CreateElement("Id");
      Id.AppendChild(doc.CreateTextNode("123456789"));
      venta.AppendChild(Id);

      XmlElement Can = doc.CreateElement("Cantidad");
      Can.AppendChild(doc.CreateTextNode("9874561230"));
      venta.AppendChild(Can);

      XmlElement Pt = doc.CreateElement("PrecioTotal");
      Pt.AppendChild(doc.CreateTextNode("20.000"));
      venta.AppendChild(Pt);

      XmlElement Des = doc.CreateElement("Descuento");
      Des.AppendChild(doc.CreateTextNode("0"));
      venta.AppendChild(Des);

      XmlElement EmId = doc.CreateElement("EmpleadoId");
      EmId.AppendChild(doc.CreateTextNode("99012700241"));
      venta.AppendChild(EmId);

      XmlElement VeId = doc.CreateElement("VentaId");
      VeId.AppendChild(doc.CreateTextNode("0001"));
      venta.AppendChild(VeId);

      doc.Save("C:/Users/Migue/Documents/Repositories/le-teburu/Xml/Archivo.Xml");

      return doc;

    }

  }
}
