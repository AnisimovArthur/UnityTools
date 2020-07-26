# Summary
Unity package with Editor and Runtime tools.

**Note:** this package in preview version. Feel free to use Issues and Pull requests to contribute.

# Table of contents

### Getting started
* [Install (Package Manager)](#gs-install-pm)
* [Install (Manifest)](#gs-install-manifest)
* [Update](#gs-update)

### Runtime Tools
   * [Scheduler](#rt-scheduler)
   * [Event Handler](#rt-eventhandler)
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
   * [Toolbar Scene Loader](#et-toolbarsceneloader)
   * [Inspector Button](#et-inspectorbutton)
   
# Getting Started

**Note:** If you use [**Assembly Definitions**](https://docs.unity3d.com/Manual/ScriptCompilationAssemblyDefinitionFiles.html) you have to add references to your Assembly Definition. 
Add ```Archie.UnityTools.Editor.asmdef``` in order to use Editor Tools.
Add ```Archie.UnityTools.Runtime.asmdef``` in order to use Runtime Tools.

## <a id="gs-install-pm"></a>Install package via Package Manager
You can add the package dependency via Unity's Package Manager .
1. Open Package Manager: Window -> Package Manager.
2. From the top left, click on the "+" button.
3. Input ```https://github.com/AnisimovArthur/UnityTools.git``` in the input field.
4. Click Add.

## <a id="gs-install-manifest"></a>Install package via Manifest
The second option is to install via the manifest.

To use the package you have to add the dependency to the project's Packages/manifest.json file.
```json
"com.archie.unitytools": "https://github.com/AnisimovArthur/UnityTools.git#v0.2.0-preview",
```

## <a id="gs-update"></a>Update package
To update the package you have to update the dependency version in the project's Packages/manifest.json file.

For example:

Old: ```#v0.0.2-preview``` 
New: ```#v0.1.1-preview```

# Runtime Tools
## <a id="rt-scheduler"></a>Scheduler
Tool for delayed event execution.

```csharp
using UnityEngine;
using UnityTools;

public class SchedulerExample : MonoBehaviour
{
    private void Awake()
    {
        // Debug.Log should happens in 2 seconds.
        var scheduled = Scheduler.Schedule(2.0f, () => Debug.Log("Hello World!"));

        // First option to cancel Debug.Log("Hello World!") above
        scheduled.Cancel();

        // Second option to cancel Debug.Log("Hello World!") above
        // Scheduler.Cancel(scheduled);

        // As a result, you will see only "I'm a cat." in the console because "scheduled" was canceled above
        Scheduler.Schedule(0.5f, delegate
        {
            Debug.Log("I'm a cat.");
        });
    }
}
```

## <a id="rt-eventhandler"></a>Event Handler

Generic Event System.
The Event System allows components to Subscribe, Unsubscribe, and Execute events.

```csharp
using UnityEngine;
using UnityTools;

public class FirstComponent : MonoBehaviour
{
    private void Awake()
    {
        EventHandler.Subscribe<string, GameObject>("FirstEvent", PrintMessage);
        EventHandler.Subscribe("SecondEvent", PrintHello);

        EventHandler.Unsubscribe("SecondEvent", PrintHello);

        EventHandler.Execute("FirstEvent", Time.time.ToString(), gameObject);
        EventHandler.Execute("SecondEvent");
    }

    private void PrintHello()
    {
        Debug.Log("Hello");
    }

    private void PrintMessage(string message, GameObject obj)
    {
        Debug.Log(message + " " + obj.name);
    }
}
```
As a result, you will see in the console

1) 0 GameObject

You will not see "Hello" a second time because you are unsubscribing from this event in the code.

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
    ToolbarTools.AddTool(new ToolbarButton("Button", PrintMessage), ToolbarSide.Left);
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

#### Icon for toolbar items
You can provide a tool icon as shown below.

```csharp
static ToolbarExample()
{
    var icon = Resources.Load<Texture>($"YOUR_PATH_TO_ICON");
    ToolbarTools.AddTool(new ToolbarButton("Button", icon), ToolbarSide.Left);
}
```

# <a id="et-toolbarsceneloader"></a>Toolbar Scene Loader

This tool is developed by [Toolbar](#et-toolbar) functionality. You can easily add quick access to your scenes.

<img src="https://i.imgur.com/TtWOWmH.png" alt="alt text" width="451" height="155">

```csharp
using UnityEditor;

using UnityTools.Editor;

[InitializeOnLoad]
public static class ToolbarLoaderToolExample
{
    static ToolbarLoaderToolExample()
    {
        ToolbarSceneLoader.AddScene("Scene 1", "Content/Scenes/1.unity");
        ToolbarSceneLoader.AddSeparator("Other Scenes");
        ToolbarSceneLoader.AddScene("Test Scenes/Test Scene 1", "Content/Scenes/Test/Test 1");
    }
}
```

# <a id="et-inspectorbutton"></a>Inspector Button

```csharp
using UnityEngine;

#if UNITY_EDITOR
using UnityTools.Editor;
#endif

public class Example : MonoBehaviour
{
    private const string ExampleString = "Example string";

#if UNITY_EDITOR
    [Button("Do Log ExampleString")]
    private void DoSomething()
    {
        Debug.Log(ExampleString);
    }
#endif
}
```

**Note:** you have to use [**Platform dependent compilation**](https://docs.unity3d.com/Manual/PlatformDependentCompilation.html)  in order to have an Inspector Button in Runtime code.

<img src="https://i.imgur.com/mhfZAEz.png" alt="alt text" width="527" height="432">

# License
This package licensed under the [MIT license](https://github.com/AnisimovArthur/UnityTools/blob/master/LICENSE).
