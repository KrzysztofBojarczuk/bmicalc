namespace bmiwebApi.Repositories
{
    public interface IBodyRepository
    {
        Task<List<Body>> GetAllBodyAsync();
        Task<Body> GetBodyByIdAsync(int id);
        Task<Body> CreateBodyAsync(Body body);
        Task<Body> UpdateBodyAsync(Body updatebody);
        Task<Body> DeleteBodyAsync(int id);
    }
}
