using Italian_Restaurant_1.Models;
namespace Italian_Restaurant_1.Repository
{
	public interface RecipeCategoryInterface
	{
		Category Add(Category category);
		Category Update(Category category);
		Category Delete(int catID);
		Category Get(int catID);

		IEnumerable<Category> GetAllCategory();

	}
}
