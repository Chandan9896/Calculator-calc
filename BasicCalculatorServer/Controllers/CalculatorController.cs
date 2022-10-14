using BasicCalculatorServer.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BasicCalculatorServer.Controllers
{
    [Route("api/calculator")]
    public class CalculatorController : Controller
    {
        [HttpGet("fnum/{fnum}/snum/{snum}/operation/{operation}")]
        public async Task<double> Get(double fnum, double snum, string operation)
        {

            var res = operation switch
            {
                "add" => fnum + snum,
                "subtract" => fnum - snum,
                "multiply" => fnum * snum,
                "divide" => fnum / snum,
            };

            var dbModel = new CalculatorDbModel();
            dbModel.Id = new Guid();
            dbModel.CreatedOn = DateTime.Now;
            dbModel.fnum = fnum;
            dbModel.snum = snum;
            dbModel.otr = operation;
            dbModel.res = res;
            var collections = GetCollections("CalculatorDbModel");
            collections.InsertOne(dbModel);
            return res;
        }

        public IMongoCollection<CalculatorDbModel> GetCollections(string collectionName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Calculator");
            return database.GetCollection<CalculatorDbModel>(collectionName);
        }
    }
}
