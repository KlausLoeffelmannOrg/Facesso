#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Security.Cryptography;
using System.Collections.ObjectModel;

#endregion

namespace ActiveDev.Printing
{
	public interface IADPrintableObject
	{
		SizeF MeasureSize(Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage);
		bool KeepWithNext { get; set; }
		PointF Location { get; set; }
		SizeF Size { get; set; }
		void Render(Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage);
		IADPrintableObject GetFirstPrintableObject();
		IADPrintableObject GetNextPrintableObject();
		ADPrintableObjectPair PartitionObject(Graphics g, float LeftHeightCurrentPage, ADSimplePrintDocumentDefaultPage currentDefaultPage, float NextPageWidth);
		bool IsTableHeader { get; set; }
		bool IsTableRow { get; set; }
		float DistanceToNext { get; set; }
		int PageBreakAfter { get; set; }
		object Tag { get; set; }
	}

	public abstract class ADPrintableObjectBase : IADPrintableObject
	{
		protected bool myKeepWithNext;
		protected PointF myLocation;
		protected SizeF mySize;
		protected bool myIsTableHeader;
		protected bool myIsTableRow;
		protected int myPageBreakAfter;
		protected float myDistanceToNext;
		protected object myTag;

		public virtual bool KeepWithNext
		{
			get { return myKeepWithNext; }
			set { myKeepWithNext=value; }
		}

		public virtual PointF Location
		{
			get { return myLocation; }
			set { myLocation=value; }
		}

		public virtual SizeF Size
		{
			get	{ return mySize; }
			set { mySize = value; }
		}

		public virtual bool IsTableHeader
		{
			get { return myIsTableHeader; }
			set { myIsTableHeader = value; }
		}

		public virtual bool IsTableRow
		{
			get { return myIsTableRow; }
			set { myIsTableRow = value; }
		}

		public virtual int PageBreakAfter
		{
			get { return myPageBreakAfter; }
			set { myPageBreakAfter= value; }
		}

		public virtual float DistanceToNext
		{
			get { return myDistanceToNext; }
			set { myDistanceToNext = value; }
		}

		public virtual object Tag
		{
			get { return myTag; }
			set { myTag = value; }
		}

		public virtual IADPrintableObject GetFirstPrintableObject()
		{
			return this;
		}

		public virtual IADPrintableObject GetNextPrintableObject()
		{
			return null;
		}

		public virtual ADPrintableObjectPair PartitionObject(Graphics g, float LeftHeightCurrentPage, ADSimplePrintDocumentDefaultPage currentDefaultPage, float NextPageWidth)
		{
			return null;
		}

		public abstract void Render(Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage);
		public abstract SizeF MeasureSize(Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage);
	}

	public class ADPrintableObjects : KeyedCollection<string,IADPrintableObject>
	{
		String myNextKeyToAssign;

		public void Add(String key, IADPrintableObject printableObject)
		{
			myNextKeyToAssign = key;
		}

		protected override string GetKeyForItem(IADPrintableObject item)
		{
			if (myNextKeyToAssign != null)
			{
				String locKeyToReturn = myNextKeyToAssign;
				myNextKeyToAssign = null;
				return locKeyToReturn;
			}
			else
			{
				return CreateGuid().ToString();
			}
		}

		internal Guid CreateGuid()
		{
			Byte[] locRandomBytes=new Byte[16];
			RNGCryptoServiceProvider locRandom = new RNGCryptoServiceProvider();
			
			locRandom.GetBytes(locRandomBytes);
			Guid locGuid = new Guid(locRandomBytes);
			return locGuid;
		}
	}

	public class ADPrintableObjectPair
	{
		IADPrintableObject myFirstObject;
		IADPrintableObject mySecondObject;

		public ADPrintableObjectPair(IADPrintableObject first, IADPrintableObject second)
		{
			myFirstObject = first;
			mySecondObject = second;
		}

		public IADPrintableObject FirstObject
		{
			get	{ return myFirstObject; }
			set	{ myFirstObject = value; }
		}

		public IADPrintableObject SecondObject
		{
			get { return mySecondObject; }
			set { mySecondObject = value; }
		}
	}
}
