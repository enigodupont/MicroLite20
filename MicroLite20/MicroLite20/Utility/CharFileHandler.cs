using MicroLite20.Utility;
using Newtonsoft.Json;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace MicroLite20.Utility
{
    public class CharFileHandler {

        public static IFileSystem fileSystem = FileSystem.Current;
        public static IFolder rootFolder = fileSystem.LocalStorage;

        public async static void SaveCharacterToFileSystem(CharacterData data) {
            string fileName = data.characterName + "_" + data.charRace + "_" + data.characterClassString;
            IFolder charFolder = await rootFolder.CreateFolderAsync("charFolder", CreationCollisionOption.OpenIfExists);
            IFile savedChar = await charFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await savedChar.WriteAllTextAsync(data.serialize());

        }

        public async static Task<List<String>> getAllCharacterFromFileSystem() {
            List<String> fileNames = new List<String>();
            IFolder charFolder = await rootFolder.CreateFolderAsync("charFolder", CreationCollisionOption.OpenIfExists);
            IList<IFile> fileList = await charFolder.GetFilesAsync();

            foreach(IFile file in fileList) {
                fileNames.Add(file.Name);
            }

            return fileNames;
        }


        public async static Task<CharacterData> LoadCharacterFromFileSystem(string fileName) {
            IFolder charFolder = await rootFolder.CreateFolderAsync("charFolder", CreationCollisionOption.OpenIfExists);
            IFile charToLoad = await charFolder.GetFileAsync(fileName);

            if (charToLoad != null) {

                String readText = await charToLoad.ReadAllTextAsync();
                JsonSerializerSettings settings = new JsonSerializerSettings() {
                    TypeNameHandling = TypeNameHandling.All
                };
                return JsonConvert.DeserializeObject<CharacterData>(readText,settings);
            } else {
                return null;
            }
            
        }


        public static async void DeleteCharacterFromFileSystem(CharacterData data) {
            string fileName = data.characterName + "_" + data.charRace + "_" + data.characterClass;
            IFolder charFolder = await rootFolder.CreateFolderAsync("charFolder", CreationCollisionOption.OpenIfExists);
            IFile savedChar = await charFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            await savedChar.DeleteAsync();


        }
    }
}
