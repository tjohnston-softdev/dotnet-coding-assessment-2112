using System;
using System.Collections.Generic;
using NUnit.Framework;
using PalindromePartitions.Classes;
using PalindromePartitions.Tests.Common;

namespace PalindromePartitions.Tests
{
    // Unit tests for 'Partition' object class.
	[TestFixture]
	public class PartitionObjectTests
    {
		// Object type shortcut.
		private static readonly Type ObjectType = typeof(Partition);
		
		// Error message strings.
		private static readonly string NegativeText = "Non-negative number required. (Parameter 'index')";
		private static readonly string BoundText = WriteBoundErrorText();
		
		
		// Class object schema.
		[Test]
        public void ObjectSchema()
        {
			// Value types.
			Type intType = typeof(int);
			Type strType = typeof(string);
			Type strListType = typeof(List<string>);
			
			// 'Count' property.
			SchemaValidation.CheckProperty(ObjectType, "Count", intType);
			
			// Constructor functions.
			SchemaValidation.CheckMethod(ObjectType, "Initialize", ObjectType, true);
			SchemaValidation.CheckMethod(ObjectType, "Empty", ObjectType, true);
			SchemaValidation.CheckMethod(ObjectType, "Parse", ObjectType, true);
			SchemaValidation.CheckMethod(ObjectType, "Derive", ObjectType, true);
			
			// Object functions.
			SchemaValidation.CheckMethod(ObjectType, "Slice", strListType, false);
			SchemaValidation.CheckMethod(ObjectType, "MergeSubstrings", strType, false);
			SchemaValidation.CheckMethod(ObjectType, "Join", strType, false);
			SchemaValidation.CheckMethod(ObjectType, "GetSubstring", strType, false);
        }
		
		
		// 'Join' function.
		[Test]
		public void JoinFunction()
		{
			Partition emptyObj = Partition.Empty();
			string emptyJoin = emptyObj.Join();
			Assert.AreEqual(emptyJoin, "");
		}
		
		
		// 'Empty' constructor.
		[Test]
        public void EmptyObjectConstructor()
        {
			Partition emptyObj = Partition.Empty();
			Assert.AreEqual(emptyObj.Count, 0);
        }
		
		
		// 'Initialize' constructor - Valid.
		[Test]
		public void InitializeObjectConstructorValid()
		{
			string entryString = "quickbrownfox";
			Partition intlObj = Partition.Initialize(ref entryString);
			Assert.IsInstanceOf(ObjectType, intlObj);
			Assert.AreEqual(intlObj.Count, entryString.Length);
			PartitionContents.CompareInitializedConstructor(ref entryString, intlObj);
		}
		
		
		// 'Initialize' constructor - Some characters invalid.
		[Test]
		public void InitializeObjectConstructorInvalidSome()
		{
			string entryString = "qu!ck_8r0wn-f0%";
			Partition intlObj = Partition.Initialize(ref entryString);
			PartitionContents.Check(intlObj);
		}
		
		
		// 'Initialize' constructor - All characters invalid.
		[Test]
		public void InitializeObjectConstructorInvalidOnly()
		{
			string entryString = "!@#$%^&*()";
			Partition intlObj = Partition.Initialize(ref entryString);
			Assert.AreEqual(intlObj.Count, 0);
		}
		
		
		// 'Initialize' constructor - Empty string.
		[Test]
		public void InitializeObjectConstructorEmpty()
		{
			string entryString = "";
			Partition intlObj = Partition.Initialize(ref entryString);
			Assert.AreEqual(intlObj.Count, 0);
		}
		
		
		// 'Parse' constructor - Valid.
		[Test]
		public void ParseObjectConstructorValid()
		{
			string entryString = "meow,tacocat,hiss";
			Partition parsedObj = Partition.Parse(entryString);

            Assert.IsInstanceOf(ObjectType, parsedObj);
			Assert.AreEqual(parsedObj.Count, 3);
			string actualJoin = PartitionContents.Check(parsedObj);
			Assert.AreEqual(entryString, actualJoin);
		}
		
		
		// 'Parse' constructor - Some characters invalid.
		[Test]
		public void ParseObjectConstructorInvalidSome()
		{
			Partition parsedObj = Partition.Parse("ab(d,efgh,!jkl,mnop,qrs+,uvwx,yz");
			PartitionContents.Check(parsedObj);
		}
		
		
		
		// 'Parse' constructor - All characters invalid.
		[Test]
		public void ParseObjectConstructorInvalidOnly()
		{
			Partition parsedObj = Partition.Parse("!@#,$%^,&*(");
			Assert.AreEqual(parsedObj.Count, 0);
		}
		
		
		// 'Parse' constructor - Empty string.
		[Test]
		public void ParseObjectConstructorEmpty()
		{
			Partition parsedObj = Partition.Parse("");
			Assert.AreEqual(parsedObj.Count, 0);
		}
		
		
		// 'Slice' function - Valid.
		[Test]
		public void SliceValid()
		{
			Partition entryObject = GetFullInput();
			List<string> subList = entryObject.Slice(2, 3);
			
			Assert.IsInstanceOf(typeof(List<string>), subList);
			Assert.AreEqual(subList.Count, 3);
			
			Assert.AreEqual(subList[0], "ghi");
			Assert.AreEqual(subList[1], "jkl");
			Assert.AreEqual(subList[2], "mno");
		}
		
		
		// 'Slice' function - Empty length.
		[Test]
		public void SliceEmpty()
		{
			Partition entryObject = GetFullInput();
			List<string> subList = entryObject.Slice(-1, 0);
			Assert.AreEqual(subList.Count, 0);
		}
		
		
		// 'Slice' function - Negative index.
		[Test]
		public void SliceNegative()
		{
			Partition entryObject = GetFullInput();
			TryCatchResult testOutcome = InvalidCalls.PartitionSlice(entryObject, -1, 2);
			InvalidCalls.CheckErrorResult(testOutcome, NegativeText);
		}
		
		
		// 'Slice' function - Overflow.
		[Test]
		public void SliceOverflow()
		{
			Partition entryObject = GetFullInput();
			TryCatchResult testOutcome = InvalidCalls.PartitionSlice(entryObject, 5, 100);
			InvalidCalls.CheckErrorResult(testOutcome, BoundText);
		}
		
		
		// 'MergeSubstrings' function - Valid.
		[Test]
		public void MergeValid()
		{
			Partition entryObject = GetFullInput();
			string mergedText = entryObject.MergeSubstrings(2, 4);
			Assert.AreEqual(mergedText, "ghijklmno");
		}
		
		
		// 'MergeSubstrings' function - Single substring only.
		[Test]
		public void MergeSingle()
		{
			Partition entryObject = GetFullInput();
			string singleText = entryObject.MergeSubstrings(4, 4);
			Assert.AreEqual(singleText, "mno");
		}
		
		
		// 'MergeSubstrings' function - Flipped indexes.
		[Test]
		public void MergeFlipped()
		{
			Partition entryObject = GetFullInput();
			string mergedText = entryObject.MergeSubstrings(3, 1);
			Assert.AreEqual(mergedText, "defghijkl");
		}
		
		
		// 'MergeSubstrings' function - Negative index.
		[Test]
		public void MergeNegative()
		{
			Partition entryObject = GetFullInput();
			TryCatchResult testOutcome = InvalidCalls.PartitionMerge(entryObject, -1, 3);
			InvalidCalls.CheckErrorResult(testOutcome, NegativeText);
		}
		
		// 'MergeSubstrings' function - Overflow.
		[Test]
		public void MergeOverflow()
		{
			Partition entryObject = GetFullInput();
			TryCatchResult testOutcome = InvalidCalls.PartitionMerge(entryObject, 3, 99);
			InvalidCalls.CheckErrorResult(testOutcome, BoundText);
		}
		
		// 'GetSubstring' function - Valid.
		[Test]
		public void GetValid()
		{
			Partition entryObject = GetFullInput();
			string retrievedText = entryObject.GetSubstring(2);
			Assert.AreEqual(retrievedText, "ghi");
		}
		
		
		// 'GetSubstring' function - Unknown.
		[Test]
		public void GetUnknown()
		{
			Partition entryObject = GetFullInput();
			string retrievedText = entryObject.GetSubstring(-1);
			Assert.AreEqual(retrievedText, "");
		}
		
		
		// 'Derive' constructor - Add at beginning.
		[Test]
		public void DeriveObjectConstructorBegin()
		{
			Partition originalObject = Partition.Parse("ta,co,cat,abc,def");
			Partition derivedObject = Partition.Derive(originalObject, "tacocat", 0, 2);

            Assert.IsInstanceOf(ObjectType, derivedObject);
			string deriveJoin = derivedObject.Join();
			
			Assert.AreEqual(deriveJoin, "tacocat,abc,def");
		}
		
		
		// 'Derive' constructor - Add in middle.
		[Test]
		public void DeriveObjectConstructorMiddle()
		{
			Partition originalObject = Partition.Parse("abc,def,ta,co,cat,ghi,jkl");
			Partition derivedObject = Partition.Derive(originalObject, "tacocat", 2, 4);
			string deriveJoin = derivedObject.Join();
			
			Assert.AreEqual(deriveJoin, "abc,def,tacocat,ghi,jkl");
		}
		
		// 'Derive' constructor - Add to end.
		[Test]
		public void DeriveObjectConstructorEnd()
		{
			Partition originalObject = Partition.Parse("abc,def,ghi,ta,co,cat");
			Partition derivedObject = Partition.Derive(originalObject, "tacocat", 3, 5);
			string deriveJoin = derivedObject.Join();
			
			Assert.AreEqual(deriveJoin, "abc,def,ghi,tacocat");
		}
		
		
		// Retrieve valid input for object functions.
		private static Partition GetFullInput()
		{
			Partition inputRes = Partition.Parse("abc,def,ghi,jkl,mno,pqrs,tuv,wxyz");
			return inputRes;
		}
		
		// Write 'out of bounds' error text.
		private static string WriteBoundErrorText()
		{
			string writeRes = "";
			
			writeRes += "Offset and length were out of bounds for the array ";
			writeRes += "or count is greater than the number of elements from index to the end of the source collection.";
			
			return writeRes;
		}
		
    }
}