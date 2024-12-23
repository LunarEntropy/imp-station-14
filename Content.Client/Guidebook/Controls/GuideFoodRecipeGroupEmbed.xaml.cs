using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Content.Client.Guidebook.Richtext;
using Content.Shared.Kitchen;
using JetBrains.Annotations;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Prototypes;

namespace Content.Client.Guidebook.Controls;

/// <summary>
///     Control for embedding a FoodRecipe into a guidebook.
/// </summary>
[UsedImplicitly, GenerateTypedNameReferences]
public sealed partial class GuideFoodRecipeGroupEmbed : BoxContainer, IDocumentTag
{
    [Dependency] private readonly IPrototypeManager _prototype = default!;

    public GuideFoodRecipeGroupEmbed()
    {
        RobustXamlLoader.Load(this);
        IoCManager.InjectDependencies(this);
        MouseFilter = MouseFilterMode.Stop;
    }

    public GuideFoodRecipeGroupEmbed(string group) : this()
    {
        var prototypes = _prototype.EnumeratePrototypes<FoodRecipePrototype>().OrderBy(p => p.Name);
        foreach (var FoodRecipe in prototypes)
        {
            var embed = new GuideFoodRecipeEmbed(FoodRecipe);
            GroupContainer.AddChild(embed);
        }
    }

    public bool TryParseTag(Dictionary<string, string> args, [NotNullWhen(true)] out Control? control)
    {
        control = null;

        var prototypes = _prototype.EnumeratePrototypes<FoodRecipePrototype>().OrderBy(p => p.Name);
        foreach (var FoodRecipe in prototypes)
        {
            var embed = new GuideFoodRecipeEmbed(FoodRecipe);
            GroupContainer.AddChild(embed);
        }

        control = this;
        return true;
    }
}
