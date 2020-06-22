using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace MainApplication
{
    //this class is used by the Designer to render the properties in the "Properties Window"
    //and also to save/serialize the code generated to the Designer.cs file
    public class CoordinateConverter: TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            //we must return true if the "sourceType" is string since we have a ToString method in Coordinate class
            return sourceType == typeof(string)
                || base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string)
                || base.CanConvertTo(context, destinationType)
                || destinationType == typeof(InstanceDescriptor); //InstanceDescriptor is used by Designer on serialization to .cs file
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            //straight-forward cast to "Coordinate" object
            return (Coordinate)value;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
                return value.ToString();
            else if (destinationType == typeof(InstanceDescriptor))
            {
                //get the constructor of the "Coordinate" object
                ConstructorInfo[] ctor = typeof(Coordinate).GetConstructors();

                //we can extract the values of X and Y on the value.ToString() and store it in a List
                List<int> parameters = new List<int>();
                foreach (string parameter in value.ToString().Replace(" ", "").Split(','))
                    parameters.Add(int.Parse(parameter));

                //param1 = constructor of the object
                //param2 = values of the parameters of the constructor
                return new InstanceDescriptor(ctor[0], parameters);
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            //straight-forward creation of Coordinate object
            return new Coordinate(int.Parse(propertyValues["X"].ToString()), int.Parse(propertyValues["Y"].ToString()));
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            //we will just return the properties (X and Y) of the object Coordinate
            return TypeDescriptor.GetProperties(value);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
    //lets build and test
}
