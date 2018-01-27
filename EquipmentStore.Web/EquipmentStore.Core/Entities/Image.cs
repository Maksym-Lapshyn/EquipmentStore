﻿namespace EquipmentStore.Core.Entities
{
    public abstract class Image
	{
		public string Name { get; set; }

		public string MimeType { get; set; }

		public byte[] Data { get; set; }
	}
}
