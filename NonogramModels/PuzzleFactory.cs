using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace NonogramModels
{
    public class PuzzleFactory
    {
        public const string Filename = "Puzzle.json";

        public static async Task SavePuzzle(CreatedPuzzle puzzle)
        {
            var appFolder = ApplicationData.Current.LocalFolder;

            var file = await appFolder.CreateFileAsync(Filename, CreationCollisionOption.OpenIfExists);

            var list = await GetSavedPuzzles();
            if (list == null)
            {
                list = new List<CreatedPuzzle>();
            }

            list.Add(puzzle);

            if (file != null)
            {
                await FileIO.WriteTextAsync(file, JsonConvert.SerializeObject(list));
            }
        }

        public static async Task<List<CreatedPuzzle>> GetSavedPuzzles()
        {

            var appFolder = ApplicationData.Current.LocalFolder;
            var file = await appFolder.CreateFileAsync(Filename, CreationCollisionOption.OpenIfExists);

            if (file != null)
            {
                var read = await FileIO.ReadTextAsync(file);
                var list = JsonConvert.DeserializeObject<List<CreatedPuzzle>>(read);

                return list;
            }

            return new List<CreatedPuzzle>();
        }
    }
}
