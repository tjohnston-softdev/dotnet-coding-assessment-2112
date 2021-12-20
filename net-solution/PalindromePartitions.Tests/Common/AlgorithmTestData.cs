using System;
using System.Collections.Generic;

namespace PalindromePartitions.Tests.Common
{
    // Stores input and output test data for partitioning algorithm.
	public class AlgorithmTestData
    {
		// Private properties - Input
		private static string pGeeksInput = "geeks";
		private static string pLettersInput = "aab";
		private static string pCustomInput = "thequickbrownfoxnamedottojumpsoverthelazytacocatlastnight";
		
		// Private properties - Output
		private static List<string> pGeeksOutput = DefineGeeksExpect();
		private static List<string> pLettersOutput = DefineLettersExpect();
		private static List<string> pCustomOutput = DefineCustomExpect();
		
		
		// Function writes expexted 'Geeks' output.
		private static List<string> DefineGeeksExpect()
		{
			List<string> defineRes = new List<string>();
			defineRes.Add("g,e,e,k,s");
			defineRes.Add("g,ee,k,s");
			return defineRes;
		}
		
		
		// Function writes expexted 'Letters' output.
		private static List<string> DefineLettersExpect()
		{
			List<string> defineRes = new List<string>();
			defineRes.Add("a,a,b");
			defineRes.Add("aa,b");
			return defineRes;
		}
		
		
		// Function writes expexted 'Custom' output.
		private static List<string> DefineCustomExpect()
		{
			List<string> defineRes = new List<string>();
			
			defineRes.Add("t,h,e,q,u,i,c,k,b,r,o,w,n,f,o,x,n,a,m,e,d,o,t,t,o,j,u,m,p,s,o,v,e,r,t,h,e,l,a,z,y,t,a,c,o,c,a,t,l,a,s,t,n,i,g,h,t");
			defineRes.Add("t,h,e,q,u,i,c,k,b,r,o,w,n,f,o,x,n,a,m,e,d,o,tt,o,j,u,m,p,s,o,v,e,r,t,h,e,l,a,z,y,t,a,c,o,c,a,t,l,a,s,t,n,i,g,h,t");
			defineRes.Add("t,h,e,q,u,i,c,k,b,r,o,w,n,f,o,x,n,a,m,e,d,o,t,t,o,j,u,m,p,s,o,v,e,r,t,h,e,l,a,z,y,t,a,coc,a,t,l,a,s,t,n,i,g,h,t");
			defineRes.Add("t,h,e,q,u,i,c,k,b,r,o,w,n,f,o,x,n,a,m,e,d,otto,j,u,m,p,s,o,v,e,r,t,h,e,l,a,z,y,t,a,c,o,c,a,t,l,a,s,t,n,i,g,h,t");
			defineRes.Add("t,h,e,q,u,i,c,k,b,r,o,w,n,f,o,x,n,a,m,e,d,o,t,t,o,j,u,m,p,s,o,v,e,r,t,h,e,l,a,z,y,t,acoca,t,l,a,s,t,n,i,g,h,t");
			defineRes.Add("t,h,e,q,u,i,c,k,b,r,o,w,n,f,o,x,n,a,m,e,d,o,t,t,o,j,u,m,p,s,o,v,e,r,t,h,e,l,a,z,y,tacocat,l,a,s,t,n,i,g,h,t");
			defineRes.Add("t,h,e,q,u,i,c,k,b,r,o,w,n,f,o,x,n,a,m,e,d,o,tt,o,j,u,m,p,s,o,v,e,r,t,h,e,l,a,z,y,t,a,coc,a,t,l,a,s,t,n,i,g,h,t");
			defineRes.Add("t,h,e,q,u,i,c,k,b,r,o,w,n,f,o,x,n,a,m,e,d,o,tt,o,j,u,m,p,s,o,v,e,r,t,h,e,l,a,z,y,t,acoca,t,l,a,s,t,n,i,g,h,t");
			defineRes.Add("t,h,e,q,u,i,c,k,b,r,o,w,n,f,o,x,n,a,m,e,d,o,tt,o,j,u,m,p,s,o,v,e,r,t,h,e,l,a,z,y,tacocat,l,a,s,t,n,i,g,h,t");
			defineRes.Add("t,h,e,q,u,i,c,k,b,r,o,w,n,f,o,x,n,a,m,e,d,otto,j,u,m,p,s,o,v,e,r,t,h,e,l,a,z,y,t,a,coc,a,t,l,a,s,t,n,i,g,h,t");
			defineRes.Add("t,h,e,q,u,i,c,k,b,r,o,w,n,f,o,x,n,a,m,e,d,otto,j,u,m,p,s,o,v,e,r,t,h,e,l,a,z,y,t,acoca,t,l,a,s,t,n,i,g,h,t");
			defineRes.Add("t,h,e,q,u,i,c,k,b,r,o,w,n,f,o,x,n,a,m,e,d,otto,j,u,m,p,s,o,v,e,r,t,h,e,l,a,z,y,tacocat,l,a,s,t,n,i,g,h,t");
			
			return defineRes;
		}
		
		
		// Public 'Geeks' input property.
		public static string geeksInput
		{
			get {return pGeeksInput;}
		}
		
		// Public 'Letters' input property.
		public static string lettersInput
		{
			get {return pLettersInput;}
		}
		
		// Public 'Custom' input property.
		public static string customInput
		{
			get {return pCustomInput;}
		}
		
		// Public 'Geeks' output property.
		public static List<string> geeksOutput
		{
			get {return pGeeksOutput;}
		}
		
		// Public 'Letters' output property.
		public static List<string> lettersOutput
		{
			get {return pLettersOutput;}
		}
		
		// Public 'Custom' output property.
		public static List<string> customOutput
		{
			get {return pCustomOutput;}
		}
		
    }
}