﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentStore.Core.Entities
{
    public class OutputImage : Image
	{
        [ForeignKey("Output")]
        public int OutputId { get; set; }

        [Required]
		public virtual Output Output { get; set; }
	}
}
