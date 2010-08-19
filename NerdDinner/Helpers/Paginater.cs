using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Navigation;

namespace NerdDinner.Helpers
{
	public class Paginater
	{
		public int PageIndex { get; private set; }
		public int PageSize { get; private set; }
		public int TotalCount { get; private set; }
		public int TotalPages { get; private set; }

		public Paginater(int count, int pageIndex, int pageSize)
		{
			PageIndex = pageIndex;
			PageSize = pageSize;
			TotalCount = count;
			TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
		}

		public bool HasPreviousPage
		{
			get
			{
				return (PageIndex > 0);
			}
		}

		public bool HasNextPage
		{
			get
			{
				return (PageIndex + 1 < TotalPages);
			}
		}

		public string PreviousPageLink
		{
			get
			{
				if (HasPreviousPage)
				{
					StateContext.Data["page"] = PageIndex - 1;
					return StateController.RefreshLink;
				}
				return null;
			}
		}

		public string NextPageLink
		{
			get
			{
				if (HasNextPage)
				{
					StateContext.Data["page"] = PageIndex + 1;
					return StateController.RefreshLink;
				}
				return null;
			}
		}
	}
}
