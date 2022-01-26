using bmiwebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace bmiwebApi.Repositories
{
    public class BodyRepository : IBodyRepository
    {
        private readonly DataContext _ctx;

        public BodyRepository(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Body> CreateBodyAsync(Body body)
        {
            _ctx.Bodies.Add(body);
            await _ctx.SaveChangesAsync();
            return body;
        }

        public async Task<Body> DeleteBodyAsync(int id)
        {
            var body = await _ctx.Bodies.SingleOrDefaultAsync(x => x.bodyId == id);
            if (body is null)
            {
                return null;
            }
            _ctx.Bodies.Remove(body);
            await _ctx.SaveChangesAsync();
            return body;
        }

        public async Task<List<Body>> GetAllBodyAsync()
        {
          

            return await _ctx.Bodies.ToListAsync();
        }

        public async Task<Body> GetBodyByIdAsync(int id)
        {
            var body = await _ctx.Bodies.FirstOrDefaultAsync(h => h.bodyId == id);
            if (body is null)
            {
                return null;
            }
            return body;
        }

        public async Task<Body> UpdateBodyAsync(Body updatebody)
        {
            _ctx.Bodies.Update(updatebody);
            await _ctx.SaveChangesAsync();
            return updatebody;
        }
    }
}
