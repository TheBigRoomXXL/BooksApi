using BooksApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace BooksApi.Services;
public class TagsService
{
    private readonly IMongoCollection<Models.Tag> _tagsCollection;

    public TagsService(IOptions<BooksDatabaseSettings> booksDatabaseSettings, IMongoDatabase mongoDatabase)
        {
            _tagsCollection = mongoDatabase.GetCollection<Models.Tag>(booksDatabaseSettings.Value.TagsCollectionName);
        }
    public async Task<List<Models.Tag>> GetAsync() =>
        await _tagsCollection.Find(_ => true).ToListAsync();

    public async Task<Models.Tag?> GetAsync(string id) =>
        await _tagsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateIfNewAsync(Models.Tag newTag)
    {
        //await _tagsCollection.InsertOneAsync(newTag);

        //var result = await _tagsCollection.Find(x => x.Name == newTag.Name).FirstOrDefaultAsync();

        //if (result == null) { await _tagsCollection.InsertOneAsync(newTag); }
        //else { await _tagsCollection.Find(x => x.Name == newTag.Name).FirstOrDefaultAsync(); }

        //filter: Builders<Models.Tag>.Filter.Eq("name", newTag.Name),

        await _tagsCollection.ReplaceOneAsync(
            filter: x => x.Name == newTag.Name,
            options: new ReplaceOptions { IsUpsert = true },
            replacement: newTag);
    }


    public async Task UpdateAsync(string id, Models.Tag updatedTag) =>
        await _tagsCollection.ReplaceOneAsync(x => x.Id == id, updatedTag);

    public async Task RemoveAsync(string id) =>
        await _tagsCollection.DeleteOneAsync(x => x.Id == id);
}
   
