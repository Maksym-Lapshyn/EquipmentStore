using System.ComponentModel.DataAnnotations;

namespace EquipmentStore.Core.Enums
{
    public enum EquipmentCategory
    {
        [Display(Name = "С горизонтальным расположением блистерных форм")]
        WithHorizontalBlisterFormsLocation,
        [Display(Name = "С вертикальным расположением блистерных форм")]
        WithVerticalBlisterFormsLocation,
        [Display(Name = "Перистальтические насосы")]
        PeristalticPumps,
        [Display(Name = "Перистальтические дозаторы")]
        PeristalticDispensers,
        [Display(Name = "Автоматическое этикетировочное оборудование")]
        AutomaticLabelingEquipment,
        [Display(Name = "Полуавтоматическое этикетировочное оборудование")]
        SemiAutomaticLabelingEquipment,
        [Display(Name = "Линейные машины розлива")]
        LinearFillingMachines,
        [Display(Name = "Полуавтоматы розлива")]
        SemiAutomaticFillingMachines,
        [Display(Name = "Моноблоки розлива и укупорки")]
        MonoblocksForBottlingAndCapping,
        [Display(Name = "Укупорочные машины")]
        CappingMachines,
        [Display(Name = "Тубонаполнительное оборудование для пластиковых туб")]
        TubeFillingEquipmentForPlasticTubes,
        [Display(Name = "Тубонаполнительное оборудование для алюминевых туб")]
        TubeFillingEquipmentForAluminumTubes,
        [Display(Name = "Полуавтоматическое тубонаполнительное оборудование")]
        SemiAutomaticTubeFillingEquipment,
        [Display(Name = "Оборудование для производства таблеток и наполнения капсул")]
        EquipmentForProductionOfTabletsAndFillingCapsules,
        [Display(Name = "Картонажные машины")]
        CartoningMachines
    }
}
