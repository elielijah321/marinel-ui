using System;
namespace Marinel_ui.Models
{
	public class DocumentModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public DateTime? CreatedAt { get; set; }
		public string DocumentType { get; set; }
		public string URL { get; set; }
	}
}

