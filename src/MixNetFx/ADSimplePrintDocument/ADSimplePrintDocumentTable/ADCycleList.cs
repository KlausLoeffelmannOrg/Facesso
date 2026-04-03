using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ActiveDev.Printing
{

		/// <summary>
		/// Zusammendfassende Beschreibung für CycleList.
		/// </summary>
	public class CycleList : ArrayList
	{

		int index = 0;
		int startItem = 0;

		public void MoveNext()
		{
			index++;
			if (index > this.Count - 1)
				index = 0;
		}

		public void MovePrevious()
		{
			index--;
			if (index < 0)
				index = this.Count - 1;
		}

		public void MoveFirst()
		{
			index = 0;
		}

		public void MoveLast()
		{
			index = this.Count - 1;
		}

		public int CurrentIndex
		{
			get
			{
				return index;
			}
		}

		public Object CurrentItem
		{
			get
			{
				return (Object)this[index];
			}

			set
			{
				this[index] = value;
			}
		}

		public void MoveToStartItem()
		{
			index = startItem;
		}

		public int StartItem
		{
			get
			{
				return startItem;
			}

			set
			{
				int intTemp = value;
				if (intTemp > this.Count - 1)
					intTemp = this.Count - 1;
				if (intTemp < 0)
					intTemp = 0;
				startItem = intTemp;
			}
		}

		public bool Eol
		{
			get
			{
				return (index == this.Count - 1);
			}
		}

		public bool Bol
		{
			get
			{
				return (index == 0);
			}
		}

		public bool IsStartItem
		{
			get
			{
				return (index == startItem);
			}
		}
	}
}
