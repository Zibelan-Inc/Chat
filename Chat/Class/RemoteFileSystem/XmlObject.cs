using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Tools
{
    public enum XmlObjectType { Text, Element };
    public class XmlObject
    {
        public String Name;
        public XmlObject parent;
        public List<KeyValuePair<String, String>> attributes        = new List<KeyValuePair<String, String>>();
        public List<KeyValuePair<XmlObjectType, Object>> content    = new List<KeyValuePair<XmlObjectType, Object>>();

        private String EncodeIllegalCharacters(String text)
        {
            if(text.Contains("&"))
            {
                text = text.Trim();
            }
            text = text.Contains("&") ? text.Replace("&", "&amp;") : text;
            text = text.Contains("\"") ? text.Replace("\"", "&quot;") : text;
            text = text.Contains("'")  ? text.Replace("'",  "&apos;") : text;
            text = text.Contains("<")  ? text.Replace("<",  "&lt;")   : text;
            text = text.Contains(">")  ? text.Replace(">",  "&gt;")   : text;

            return text;
        }

        private String DecodeIllegalCharacters(String text)
        {
            text = text.Contains("&quot;")  ? text.Replace("&quot;", "\"") : text;
            text = text.Contains("&apos;")  ? text.Replace("&apos;", "'")  : text;
            text = text.Contains("&lt;")    ? text.Replace("&lt;",   "<")  : text;
            text = text.Contains("&gt;")    ? text.Replace("&gt;",   ">")  : text;
            text = text.Contains("&amp;")   ? text.Replace("&amp;",  "&")  : text;

            return text;
        }

        public void AddAttribute(String key, String value)
        {
            value = EncodeIllegalCharacters(value);
            attributes.Add(new KeyValuePair<String, String>(key, value));
        }

        public void AddTextContent(String text)
        {
            text = EncodeIllegalCharacters(text);
            content.Add(new KeyValuePair<XmlObjectType, Object>(XmlObjectType.Text, text));
        }

        /// <summary>
        /// Creates a child Element in this one, and returns it to you.
        /// </summary>
        /// <param name="Name">The Element name</param>
        /// <returns>An XmlObject for the child element created.</returns>
        public XmlObject CreateChildElement(String Name) 
        {
            XmlObject newElement    = new XmlObject();
            newElement.Name         = Name;
            newElement.parent       = this;
            content.Add(new KeyValuePair<XmlObjectType, Object>(XmlObjectType.Element, newElement));

            return newElement;
        }

        public XmlObject GetRootElement()
        {
            XmlObject root = this;

            while (!(root.parent == null))
            {
                root = root.parent;
            }

            return root;
        }

        /// <summary>
        /// Returns an XmlObject (Xml Element) if it exists at the path specified.
        /// </summary>
        /// <param name="path">A forward slash separated string of nested xmlobject names. Ie: RootElement/firstChildElement/secondChildElement/targetElement</param>
        /// <param name="o">An XmlObject containing the requested XmlObject on success.</param>
        /// <returns>True if the XmlObject exists, and false if not.</returns>
        public bool GetXmlObject(String path, ref XmlObject o)
        {
            String[] parts  = null;
            if(o == null)   { o = new XmlObject(); }
            bool found      = true;
            int depth       = 0;
            List<KeyValuePair<XmlObjectType, Object>> thisContent = new List<KeyValuePair<XmlObjectType, Object>>();

            // We need to create a top level container with this in it, so it can be searched:
            thisContent.Add(new KeyValuePair<XmlObjectType, Object>(XmlObjectType.Element, this));

            // An empty string means they are looking only within this Element.
            if (path.Trim().Equals("")) { path = this.Name; }

            parts = path.Contains(@"/") ? Regex.Split(path, @"/") : new String[] { "" + path };

            while(found)
            {
                found = false;
                foreach (KeyValuePair<XmlObjectType, Object> item in thisContent)
                {
                    if (item.Key.Equals(XmlObjectType.Element))
                    {
                        if (((XmlObject)item.Value).Name.Equals(parts[depth]))
                        {
                            if (depth == (parts.Length  - 1))
                            {
                                o = (XmlObject)item.Value;
                                return true;
                            } 

                            depth += 1;
                            found = true;
                            thisContent = ((XmlObject)item.Value).content;
                            break;
                        }
                    }
                }
            }
            
            return false;
        }

        /// <summary>
        /// Returns an attribute of an XmlObject (Xml Element) if it exists in the XmlObject at the path specified.
        /// </summary>
        /// <param name="path">A forward slash separated string of nested xmlobject names. Ie: RootElement/firstChildElement/secondChildElement/targetElement</param>
        /// <param name="attributeName">The name of the attribute for which you are requesting the value.</param>
        /// <param name="value">A String containing the requested value of the attribute specified on success.</param>
        /// <returns>True if the attribute exists, and false if not.</returns>
        public bool GetAttribute(String path, String attributeName, ref String value)
        {
            XmlObject xmlobject = null;
            if(GetXmlObject(path, ref xmlobject))
            {
                foreach(KeyValuePair<String, String> attribute in xmlobject.attributes)
                {
                    if(attribute.Key.Equals(attributeName))
                    {
                        value = DecodeIllegalCharacters(attribute.Value);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Returns an attribute of an XmlObject (Xml Element) if it exists in the XmlObject at the path specified.
        /// </summary>
        /// <param name="path">A forward slash separated string of nested xmlobject names. Ie: RootElement/firstChildElement/secondChildElement/targetElement</param>
        /// <param name="attributeName">The name of the attribute for which you are requesting the value.</param>
        /// <returns>A string containing ther value of the attribute, or an empry string if it doesn't exist.</returns>
        public String GetAttribute(String path, String attributeName)
        {
            XmlObject xmlobject = null;
            String retVal       = "";

            if (GetXmlObject(path, ref xmlobject))
            {
                foreach (KeyValuePair<String, String> attribute in xmlobject.attributes)
                {
                    if (attribute.Key.Equals(attributeName))
                    {
                        retVal = DecodeIllegalCharacters(attribute.Value);
                        break;
                    }
                }
            }

            return retVal;
        }

        /// <summary>
        /// Change the value of an attribute.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="attributeName"></param>
        /// <param name="newValue"></param>
        public void EditAttribute(String path, String attributeName, String newValue)
        {
            XmlObject xmlobject = null;

            if (GetXmlObject(path, ref xmlobject))
            {
                foreach (KeyValuePair<String, String> attribute in xmlobject.attributes)
                {
                    if (attribute.Key.Equals(attributeName))
                    {
                        xmlobject.attributes.Remove(attribute);
                        break;
                    }
                }
            }
            
            AddAttribute(attributeName, EncodeIllegalCharacters(newValue));
        }

        /// <summary>
        /// Returns the first item of text found in an XmlObject (Xml Element) if it exists in the XmlObject at the path specified.
        /// </summary>
        /// <param name="path">A forward slash separated string of nested xmlobject names. Ie: RootElement/firstChildElement/secondChildElement/targetElement</param>
        /// <param name="text">The text item returned, if one is found.</param>
        /// <returns>True if the XmlObject is found and there is text content in it, false otherwise.</returns>
        public bool GetTextContent(String path, ref String text)
        {
            XmlObject xmlobject = null;
            if (GetXmlObject(path, ref xmlobject))
            {
                foreach (KeyValuePair<XmlObjectType, Object> item in xmlobject.content)
                {
                    if (item.Key.Equals(XmlObjectType.Text))
                    {
                        text = ((String)item.Value).Trim();
                        text = DecodeIllegalCharacters(text);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Returns all text content items in an XmlObject (Xml Element) if it exists in the XmlObject at the path specified.
        /// </summary>
        /// <param name="path">A forward slash separated string of nested xmlobject names. Ie: RootElement/firstChildElement/secondChildElement/targetElement</param>
        /// <param name="text">A List<String>() of text items found in the specidied XmlObject.</param>
        /// <returns>True if the requested XmlObject is founs, and there is any text. False otherwise.</returns>
        public bool GetAllTextContent(String path, ref List<String> text)
        {
            XmlObject xmlobject     = null;
            if(text == null) text   = new List<String>();
            bool retVal             = false;

            if (GetXmlObject(path, ref xmlobject))
            {
                foreach (KeyValuePair<XmlObjectType, Object> item in xmlobject.content)
                {
                    if (item.Key.Equals(XmlObjectType.Text))
                    {
                        text.Add(DecodeIllegalCharacters(((String)item.Value).Trim()));
                        retVal = true;
                    }
                }
            }
            return retVal;
        }

        public String GetNameAsXmlElement(bool includeAttributes = false, bool getEndElementXml = false, bool decode = false)
        {
            StringBuilder builder = new StringBuilder();

            builder.Clear();
            builder.Append(getEndElementXml ? "</" : "<");
            builder.Append(Name);

            if (includeAttributes && !getEndElementXml)
            {
                // Scan for attributes, and add them to the name if they exist:
                if (attributes.Count > 0)
                {
                    foreach (KeyValuePair<String, String> attribute in attributes)
                    {
                        builder.Append(" ");
                        builder.Append(decode ? DecodeIllegalCharacters(attribute.Key) : attribute.Key);
                        builder.Append("=\"");
                        builder.Append(decode ? DecodeIllegalCharacters(attribute.Value) : attribute.Value);
                        builder.Append("\"");
                    }
                }
            }

            builder.Append(">");
            return builder.ToString();
        }

        /// <summary>
        /// Returns a non-formatted string containing xml created from this collection of nested XmlObjects.
        /// </summary>
        /// <returns>A string of non-formatted, generated xml</returns>
        public override string ToString()
        {
            return ToString(false);
        }

        public String ToString(bool doVisualFormatting = false)
        {
            StringBuilder rValue                                = new StringBuilder();
            Action<KeyValuePair<XmlObjectType, Object>> handler = null;

            // Create a content handler delegate that we can loop. 
            // The handler will process every Text or Element item.
            handler = (KeyValuePair<XmlObjectType, Object> content) =>
            {
                // Is it text or an element (object)?
                if (content.Key.Equals(XmlObjectType.Text))
                {
                    // Text, in this case. Add it to the treeview:
                    rValue.Append((String)content.Value);
                } else
                {
                    // In this case, it's an element.
                    XmlObject thisElement = (XmlObject)content.Value;

                    // Create the emelent xml with the attributes included:
                    rValue.Append(thisElement.GetNameAsXmlElement(true));

                    // Scan through this Element's content (Text and / or other Elements) and handle them:
                    foreach (KeyValuePair<XmlObjectType, Object> item in thisElement.content)
                    {
                        // We pass text and elements belonging to thisElement to another instance of this delegate
                        // to be handled according to their type:
                        handler(item);
                    }

                    // after all of thisElement's content has been handled, we add our EndElement tags:
                    rValue.Append(thisElement.GetNameAsXmlElement(false, true));
                }
            };

            // Add the Element name xml with attributes:
            rValue.Append(this.GetNameAsXmlElement(true));

            // Process all subitem in this root element:
            foreach (KeyValuePair<XmlObjectType, Object> SubItem in this.content)
            {
                handler(SubItem);
            }

            // Add the EndElement xml:
            rValue.Append(this.GetNameAsXmlElement(false, true));

            String returnValue = rValue.ToString();

            if(doVisualFormatting)
            {
                returnValue = returnValue.Replace("<", Environment.NewLine + "<");
                returnValue = returnValue.Replace(">",  ">" + Environment.NewLine);

                String[] parts = Regex.Split(returnValue, Environment.NewLine);
                int depth = 0;
                bool firstElementAdded = false;

                rValue.Clear();

                foreach (String part in parts)
                {
                    if (!part.Trim().Equals(""))
                    {
                        if (part.StartsWith("<") && !part.StartsWith("</") && !part.StartsWith("<?") && !part.StartsWith("<!-"))
                        {
                            if (!firstElementAdded)
                            {
                                firstElementAdded = true;
                            }
                            else
                            {
                                rValue.Append(Environment.NewLine);
                            }

                            for (int count = 0; count < depth; count++)
                            {
                                rValue.Append(" ");
                            }

                            rValue.Append(part.Trim());
                            depth += 3;
                        }
                        else if (part.StartsWith("</"))
                        {
                            depth -= 3;
                            rValue.Append(Environment.NewLine);
                            for (int count = 0; count < depth; count++)
                            {
                                rValue.Append(" ");
                            }

                            rValue.Append(part.Trim());
                        }
                        else
                        {
                            rValue.Append(Environment.NewLine);
                            for (int count = 0; count < depth; count++)
                            {
                                rValue.Append(" ");
                            }

                            rValue.Append(part.Trim());
                        }
                    }
                }
            }

            return rValue.ToString();
        }
    }

    public static class XmlParser
    {
        public static List<XmlObject> Parse(String xml)
        {
            List<XmlObject> xmlData = new List<XmlObject>();

            if (!ParseXml(xml, ref xmlData))
            {
                throw new Exception("Could not create new xmlObject(s): XML text could not be parsed.");
            }

            return xmlData;
        }

        public static String LoadFile(String filePath)
        {
            String xml = "";

            if (!File.Exists(filePath))
            {
                // File can not be found. Return ""
            } else
            {
                xml = File.ReadAllText(filePath);
            }

            return xml;
        }

        private static bool ParseXml(String rawXml, ref List<XmlObject> xmlData)
        {
            
            XmlReaderSettings settings      = new XmlReaderSettings();
            settings.ConformanceLevel       = ConformanceLevel.Fragment;
            XmlReader xml                   = XmlReader.Create(new StringReader(rawXml), settings);
            XmlObject currentXmlObject      = null;
            XmlObject tmpObject             = null;
            StringBuilder builder           = new StringBuilder();
            bool endElement                 = false;

            xml.Read();
            while (!xml.EOF)
            {
                // Don't process the XmlDeclaration, or comments or Whitespace.
                while (xml.NodeType.Equals(XmlNodeType.XmlDeclaration)
                    || xml.NodeType.Equals(XmlNodeType.Comment)
                    || xml.NodeType.Equals(XmlNodeType.Whitespace)
                    || xml.NodeType.Equals(XmlNodeType.ProcessingInstruction))
                {
                    xml.Read();

                    // Make sure we don't loop endlessly...
                    if (xml.EOF) break;
                }

                // Have we read Whitespace or comments to the EOF?
                if (xml.EOF) break;

                // Is this text, or an Element?
                if (xml.HasValue)
                {
                    // This is text
                    currentXmlObject.content.Add(new KeyValuePair<XmlObjectType, Object>(XmlObjectType.Text, xml.Value.Trim()));
                }
                else
                {
                    // Is this is an Element, or an EndElement?
                    endElement = (xml.NodeType.Equals(XmlNodeType.EndElement)) ? true : false;

                    // Create the element object:
                    tmpObject       = new XmlObject();
                    tmpObject.Name  = xml.Name;

                    // Process and add the attributes:
                    if (xml.HasAttributes)
                    {
                        for (int attributeNumber = 0; attributeNumber < xml.AttributeCount; attributeNumber++)
                        {
                            xml.MoveToAttribute(attributeNumber);
                            tmpObject.attributes.Add(new KeyValuePair<String, String>(xml.Name, xml.Value));
                        }
                    }

                    if (endElement)
                    {
                        // This is an end element:
                        // Adjust the currentXmlObject up one step:
                        currentXmlObject = currentXmlObject.parent; 
                    }
                    else
                    {
                        // Its a child element:
                        if (currentXmlObject == null)
                        {
                            // It's the first one. Assign tmpObject to currentXmlObject, and
                            currentXmlObject = tmpObject;
                            // Assign currentXmlObject to xmlData, our complete collection:
                            xmlData.Add(tmpObject);
                        }
                        else
                        {
                            currentXmlObject.content.Add(new KeyValuePair<XmlObjectType, Object>(XmlObjectType.Element, tmpObject));
                            // It's a child. Add it to the nest:
                            tmpObject.parent = currentXmlObject;
                            // And make it the current object:
                            currentXmlObject = tmpObject;
                            // Add it to the nest:
                        }

                        if (xml.IsEmptyElement)
                        {
                            // This is a "Self closing Element":
                            // Adjust the currentXmlObject up one step:
                            currentXmlObject = currentXmlObject.parent;
                        }
                    }
                }
                xml.Read();
            }
            return true;
        }
    }
}


