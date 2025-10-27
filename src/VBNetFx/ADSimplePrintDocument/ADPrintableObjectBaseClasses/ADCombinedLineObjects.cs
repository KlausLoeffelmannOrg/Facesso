#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

#endregion

namespace ActiveDev.Printing
{
	public interface IADCombinedPrintableObject : IADPrintableObject
	{
		ADPrintableObjects PrintableObjects { get; set; }
	}

	public abstract class ADCombinedPrintableObjectBase : ADPrintableObjectBase, IADCombinedPrintableObject
	{
		private ADPrintableObjects myPrintableObjects;

		public ADPrintableObjects PrintableObjects
		{
			get
			{
				if (myPrintableObjects == null)
					myPrintableObjects = new ADPrintableObjects();
				return myPrintableObjects;
			}

			set
			{
				myPrintableObjects = value;
			}
		}
	}

	public class ADCombinedLineObjects : ADCombinedPrintableObjectBase
	{
		public override SizeF MeasureSize(Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage)
		{
			float locMaxHeight = 0;

			foreach (IADPrintableObject locPO in PrintableObjects)
			{
				locPO.MeasureSize(g, currentDefaultPage);
				locMaxHeight += locPO.Size.Height;
			}

			Size = new SizeF(currentDefaultPage.CurrentPageWidth, locMaxHeight);
			return Size;
		}

		public override PointF Location
		{
			get { return myLocation; }
			set
			{
				myLocation = value;
				float myCurrentHeight = myLocation.Y;
				foreach (IADPrintableObject locPO in PrintableObjects)
				{
					locPO.Location = new PointF(myLocation.X, myCurrentHeight);
					myCurrentHeight += locPO.Size.Height;
				}

			}
		}

		public override void Render(Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage)
		{
			foreach (IADPrintableObject locPO in PrintableObjects)
			{
				locPO.Render(g, currentDefaultPage);
			}
		}
	}

}
