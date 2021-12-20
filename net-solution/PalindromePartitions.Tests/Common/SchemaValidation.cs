using System;
using System.Reflection;
using System.Collections.Generic;
using NUnit.Framework;
using PalindromePartitions.Classes;

namespace PalindromePartitions.Tests.Common
{
    // Functions used to validate class schema.
	public class SchemaValidation
    {
		
		// Check if property exists.
		public static bool CheckProperty(Type baseClass, string propName, Type propType)
		{
			PropertyInfo infoObj = baseClass.GetProperty(propName);
			bool propValid = false;
			
			if (infoObj != null && infoObj.PropertyType == propType)
			{
				// Valid.
				propValid = true;
			}
			else if (infoObj != null)
			{
				// Incorrect type.
				ThrowIncorrectPropertyType(baseClass.Name, propName, propType.Name);
			}
			else
			{
				// Not found.
				ThrowPropertyNotFound(baseClass.Name, propName);
			}
			
			return propValid;
		}
		
		// Check if method exists, static or otherwise.
		public static bool CheckMethod(Type baseClass, string methodName, Type methodReturnType, bool methodStatic)
		{
			MethodInfo infoObj = baseClass.GetMethod(methodName);
			bool methodValid = false;
			
			if (infoObj != null && infoObj.ReturnType == methodReturnType)
			{
				// Valid.
				methodValid = true;
			}
			else if (infoObj != null)
			{
				// Incorrect type.
				ThrowIncorrectReturnType(baseClass.Name, methodName, methodReturnType.Name, methodStatic);
			}
			else
			{
				// Not found.
				ThrowMethodNotFound(baseClass.Name, methodName, methodStatic);
			}
			
			return methodValid;
		}
		
		
		// 'Property not found' error.
		private static void ThrowPropertyNotFound(string vBase, string vName)
		{
			string errTxt = "";
			
			errTxt += vBase;
			errTxt += " does not have a property named ";
			errTxt += quoteName(vName);
			
			throw new Exception(errTxt);
		}
		
		
		// 'Method not found' error.
		private static void ThrowMethodNotFound(string vBase, string vName, bool vStatic)
		{
			string errTxt = "";
			
			errTxt += vBase;
			errTxt += " does not have a ";
			errTxt += WriteMethodType(vStatic);
			errTxt += "named ";
			errTxt += quoteName(vName);
			
			throw new Exception(errTxt);
		}
		
		// 'Incorrect property type' error.
		private static void ThrowIncorrectPropertyType(string vBase, string vName, string vType)
		{
			string errTxt = "";
			
			errTxt += vBase;
			errTxt += " property ";
			errTxt += quoteName(vName);
			errTxt += " must be a valid ";
			errTxt += vType;
			
			throw new Exception(errTxt);
		}
		
		// 'Incorrect return type' error.
		private static void ThrowIncorrectReturnType(string vBase, string vName, string vType, bool vStatic)
		{
			string errTxt = "";
			
			errTxt += vBase;
			errTxt += WriteMethodType(vStatic);
			errTxt += quoteName(vName);
			errTxt += " does not return a ";
			errTxt += vType;
			errTxt += " value";
			
			throw new Exception(errTxt);
		}
		
		// Writes method into error text.
		private static string WriteMethodType(bool stc)
		{
			string writeRes = " method ";
			
			if (stc == true)
			{
				writeRes = " static method ";
			}
			
			return writeRes;
		}
		
		// Writes quoted name into error text.
		private static string quoteName(string nTxt)
		{
			string quoteRes = "'" + nTxt + "'";
			return quoteRes;
		}
		
    }
}