# Summary
This is the Unity package with Editor and Runtime tools.

**Note:** this package in preview version. Feel free to use Issues and Pull requests to contribute.

# Table of contents

### Getting started
* [Install](#gs-install)
* [Update](#gs-update)

### Runtime Tools
   * Extensions
     * UI Extensions
     * Transform (RectTransform) Extensions
   * [Utils](#rt-utils)
      * [Patterns](#rt-utils-patterns)
          * [Singleton](#rt-utils-patterns-singleton)

### Editor Tools
   * [Toolbar](#et-toolbar)
      * [Toolbar Button](#et-toolbar-button)
      * [Toolbar Popup](#et-toolbar-popup)
      * [Toolbar Label](#et-toolbar-label)
   * [Inspector Button](#et-inspectorbutton)
   
# Getting Started
## <a id="gs-install"></a>Install package
To use the package you have to add the dependency to the project's Packages/manifest.json file.
```json
"com.archie.unitytools": "https://github.com/AnisimovArthur/UnityTools.git#v0.1.1-preview",
```
**Note:** If you use [**Assembly Definitions**](https://docs.unity3d.com/Manual/ScriptCompilationAssemblyDefinitionFiles.html) you have to add references to your Assembly Definition. 
Add ```Archie.UnityTools.Editor.asmdef``` in order to use Editor Tools.
Add ```Archie.UnityTools.Runtime.asmdef``` in order to use Runtime Tools.

## <a id="gs-update"></a>Update package
To update the package you have to update the dependency version in the project's Packages/manifest.json file.

For example:

Old: ```#v0.0.2-preview``` 
New: ```#v0.1.1-preview```

# Runtime Tools

## <a id="rt-utils"></a>Utils
### <a id="rt-utils-patterns"></a>Patterns
#### <a id="rt-utils-patterns-singleton"></a>Singleton

Easy-to-use Singleton implementation.

```csharp
using UnityTools;

public class Example : Singleton<Example>
{
    
}
```

# Editor Tools
## <a id="et-toolbar"></a>Toolbar

The minimum code to add a custom tool to the toolbar:
```csharp
using UnityEditor;

using UnityTools.Editor;

[InitializeOnLoad]
public class ToolbarExample
{
    static ToolbarExample()
    {
        ToolbarTools.AddTool(new ToolbarButton(), ToolbarSide.Right);
    }
}
```

<img src="https://i.imgur.com/NZ54FqH.png" alt="alt text" width="478" height="82">

###  <a id="et-toolbar-button"></a>Toolbar Button
```csharp
static ToolbarExample()
{
    ToolbarTools.AddTool(new ToolbarButton("My Button", PrintMessage), ToolbarSide.Right);
}

private static void PrintMessage()
{
    UnityEngine.Debug.Log("Editor button clicked.");
}
```
###  <a id="et-toolbar-popup"></a>Toolbar Popup
```csharp
static ToolbarExample()
{
    var genericMenu = new GenericMenu();
    genericMenu.AddItem(new UnityEngine.GUIContent("Load scene Game"), false, () => LoadSceneByName("Game"));

    ToolbarTools.AddTool(new ToolbaPopup(genericMenu, "My Popup"), ToolbarSide.Right);
}

private static void LoadSceneByName(string name)
{
    UnityEditor.SceneManagement.EditorSceneManager.LoadScene(name);
}
```
###  <a id="et-toolbar-label"></a>Toolbar Label
```csharp
static ToolbarExample()
{
    ToolbarTools.AddTool(new ToolbarLabel("My Label"), ToolbarSide.Left);
}
```

# <a id="et-inspectorbutton"></a>Inspector Button

```csharp
using UnityEngine;

using UnityTools.Editor;

public class Example : MonoBehaviour
{
    private const string exampleString = "Example string";

#if UNITY_EDITOR
    [Button("Do Log exampleString")]
    private void DoSomething()
    {
        Debug.Log(exampleString);
    }
#endif
}
```

**Note:** you have to use [**Platform dependent compilation**](https://docs.unity3d.com/Manual/PlatformDependentCompilation.html)  in order to have an Inspector Button in Runtime code.

<img src="https://i.imgur.com/mhfZAEz.png" alt="alt text" width="527" height="432">

# License
This package licensed under the [MIT license](https://github.com/AnisimovArthur/UnityTools/blob/master/LICENSE).
