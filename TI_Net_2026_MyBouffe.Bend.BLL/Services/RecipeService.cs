using System.Text.Json;
using TI_Net_2026_MyBouffe.Bend.BLL.Entities;
using TI_Net_2026_MyBouffe.Bend.BLL.Interfaces;
using TI_Net_2026_MyBouffe.Bend.BLL.Models;
using TI_Net_2026_MyBouffe.Bend.BLL.Services.Interfaces;

namespace TI_Net_2026_MyBouffe.Bend.BLL.Services
{
    public class RecipeService(IOpenAIService openAIService, IRecipeRepository recipeRepository) : IRecipeService
    {
        public async Task<List<Recipe>> GetAsync()
        {
            return recipeRepository.Get();
        }

        public async Task<Recipe> Save(Recipe recipe, string lang)
        {

            string targetLang = lang == "fr" ? "anglais" : "Francais";

            string result = (await openAIService.GetCompletionAsync(new CompletionRequest
            {
                Model = "gpt-4o",
                Messages = [
                    new CompletionRequest.Message {
                        Role = "system",
                        Content = @$"
Tu es un assistant qui va recevoir un json de l'utilisateur et devra renvoyer le meme json pret à etre parser
tout en traduisant en {targetLang} les colonnes manquantes et en corrigeant les fautes d'orthographe/grammaire.
Ajoute également le nombre de calorie par personne dans le champ correspondant.
Attention tu ne peux pas changer le contenu a ta guise le tout dois rester strictement fidele au données reçues",
                    },
                    new CompletionRequest.Message {
                        Role = "user",
                        Content = $"{recipe}",
                    },
                ],
            })).Choices.First().Message.Content;

            result = result.Replace("```json", "").Replace("```", "");

            recipe = JsonSerializer.Deserialize<Recipe>(result) ?? throw new Exception("Error parsing");

            ImageResponse data = await openAIService.GetImageAsync(new ImageRequest
            {
                Model = "dall-e-3",
                Prompt = $"Genere moi une image de {recipe.NameFr} contenant ces ingrédients {recipe.CompositionFr}",
                N = 1,
                Size = "1024x1024",
                Response_format = "b64_json",
            });
            
            string folderPath = Path.Combine("wwwroot", "Images");
            string fileName = Guid.NewGuid().ToString() + ".png";
            string imageFileName = Path.Combine(folderPath, fileName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            await File.WriteAllBytesAsync(imageFileName, data.Data.First().B64_json);

            recipe.Image = $"/Images/{fileName}";

            using Stream stream = await openAIService.GetSpeechAsync(new SpeechRequest
            {
                Model = "tts-1",
                Voice = "sage",
                Input = recipe.StepsFr,
            });

            folderPath = Path.Combine("wwwroot", "Audios");
            fileName = Guid.NewGuid().ToString() + ".mp3";
            string audioFileName = Path.Combine(folderPath, fileName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using Stream newFile = File.Create(audioFileName);

            await stream.CopyToAsync(newFile);

            recipe.AudioFr = "/Audios/" + fileName;

            using Stream streamEng = await openAIService.GetSpeechAsync(new SpeechRequest
            {
                Model = "tts-1",
                Voice = "sage",
                Input = recipe.StepsEng,
            });

            fileName = Guid.NewGuid().ToString() + ".mp3";
            audioFileName = Path.Combine(folderPath, fileName);

            using Stream newFileEng = File.Create(audioFileName);

            await streamEng.CopyToAsync(newFileEng);

            recipe.AudioEng = "/Audios/" + fileName;

            recipe.UserId = 1; // TODO Change with current user

            recipeRepository.Save(recipe);

            return recipe;
        }
    }
}
