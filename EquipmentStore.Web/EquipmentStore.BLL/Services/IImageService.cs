namespace EquipmentStore.BLL.Services
{
	public interface IImageService<in T>
	{
		void Add(T dto);

		void Delete(int id);
	}
}
