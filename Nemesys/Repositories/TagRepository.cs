using Microsoft.EntityFrameworkCore;
using Nemesys.Data;
using Nemesys.Models.Domain;

namespace Nemesys.Repositories
{
    public class TagRepository : ITagRepository
    {

        private readonly NemesysDbContext nemesysDbContext;

        public TagRepository(NemesysDbContext nemesysDbContext)
        {
            this.nemesysDbContext = nemesysDbContext;
        }


        //add
        public async Task<Tag> AddAsync(Tag tag)
        {
            await nemesysDbContext.Tags.AddAsync(tag);
            await nemesysDbContext.SaveChangesAsync();

            return tag;
        }


        //delete
        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await nemesysDbContext.Tags.FindAsync(id);

            if (existingTag != null) { }
            {
                nemesysDbContext.Tags.Remove(existingTag);
                await nemesysDbContext.SaveChangesAsync();

                return existingTag;
            }

            return null;
        }


        //get all
        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await nemesysDbContext.Tags.ToListAsync();
        }

        public Task<Tag?> GetAsync(Guid id)
        {
            return nemesysDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }


        //update
        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await nemesysDbContext.Tags.FindAsync(tag.Id);

            if(existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                await nemesysDbContext.SaveChangesAsync();

                return existingTag;
            }

            return null;
        }
    }
}
