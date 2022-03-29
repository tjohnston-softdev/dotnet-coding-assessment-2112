using System.Collections.Generic;

namespace PalindromePartitions.Tests.Common
{
    // Stores input and output test data for partitioning algorithm.
	public class AlgorithmTestData
    {
		// Private properties - Input
		private static readonly string GeeksInput = "geeks";
		private static readonly string LettersInput = "aab";
		private static readonly string CustomInput = "thequickbrownfoxnamedottojumpsoverthelazytacocatlastnight";
		
		// Private properties - Output
		private static readonly List<string> GeeksOutput = DefineGeeksExpect();
		private static readonly List<string> LettersOutput = DefineLettersExpect();
		private static readonly List<string> CustomOutput = DefineCustomExpect();
		
		
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
		public static string geeksInput => GeeksInput;

        // Public 'Letters' input property.
		public static string lettersInput => LettersInput;

        // Public 'Custom' input property.
		public static string customInput => CustomInput;

        // Public 'Geeks' output property.
		public static List<string> geeksOutput => GeeksOutput;

        // Public 'Letters' output property.
		public static List<string> lettersOutput => LettersOutput;

        // Public 'Custom' output property.
		public static List<string> customOutput => CustomOutput;
    }
}