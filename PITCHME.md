#HSLIDE?image=https://unity3d.com/files/images/ogimg.jpg

#HSLIDE

### Using Unity for scientific demonstrators and research projects

#HSLIDE

### Contents

1. Setting up a project, including questions and discussion 
2. Delegating work with (git) submodules and prefabs
3. Advanced coding tips for rapid prototyping
    1. UnityEvents
    2. Coroutines 
4. Editor scripting and advanced debugging


#HSLIDE

### Unity Overview

#VSLIDE?image=https://docs.unity3d.com/uploads/Main/monobehaviour_flowchart.svg

#VSLIDE?image=img/overview.png

#HSLIDE

### Some thoughts

- C# is a bless
- but `using UnityEngine;` is a dead end!
- using IronPython is experimental :( but [sexy](https://github.com/cesardeazevedo/Unity3D-Python-Editor)
- however, Unity is fast for rapid app prototyping (GUI [even depending on eye candy...])

#HSLIDE

### Setting up project

Unity + git

#VSLIDE

- add [.gitignore](https://github.com/github/gitignore/blob/master/Unity.gitignore) 
- what we might learn from [ignore patterns](https://github.com/github/gitignore/blob/master/Unity.gitignore#L14-L17)
- exceptions: a plugin.dll

```bash
git add -f Assets/<fizzBuzz>/Plugins/<plugin>.dll
```

#VSLIDE

Don't forget the project settings 
- SerializationMode = Force Text
- Visible Meta Files

#VSLIDE

add a useful project as submodule...

```bash
git submodule add -b master 
                  --name UnityToolbag 
                  git://github.com/nickgravelyn/UnityToolbag.git 
                  ResearchDemonstrator/Assets/UnityToolbag 
```

#VSLIDE

Pros:

- lean repositories (no code duplication in remotes)
- submodule could point to a stable state of a _work in progress_ asset package
- development branch could point to a development of the submodule

#VSLIDE

Cons: 

- more git commands necessary to manage the submodule

```bash
git clone ... -recursive
git submodule update --remote
```

- not possible with Projects maintained as whole Unity projects :(
- bad example: [HoloToolkit](https://github.com/Microsoft/HoloToolkit-Unity)

#VSLIDE

What about project settings necessary for my asset package?

Use an EditorScript which sets required values... (SettingsExample.cs)

#VSLIDE

### Idea - a project setup script

- write a [project setup script](https://github.com/xfleckx/BeMoBI_Tools/blob/master/utils/ProjectSetup/CreateNewParadigm/CreateNewParadigm/CreateNewExperiment.py) (python/bash/...) for new projects 
- import all useful repos as submodules (automatically resolve your dependency graph)

#HSLIDE

### Branching and delegating work

Example: Dev-Scene in Development branch

- corrupt prefab instances in a scene got marked red, these are "disconnected"

- Reduce merge conflicts with prefabs are easier to solve

- _instances_ of *modified* prefabs marked red in scene hierarchy

Copy -> Change -> Ready to replace

#VSLIDE

### Using prefabs

- distinct logical entities 
- containing serialized state 
- state => value + references

### Designing a prefab

- use a top level script as facade
- use public methods 
- use events for deferred or non-deterministic results 

-> Example

#VSLIDE

### Coding hint

- use assertions to signal errors and corrupt prefab states

```csharp
using UnityEngine.Assertions;
Assert.IsNotNull(myExpectedReference,"Something is missing");
```
- don't worry - got removed on compile time during the build process!

#VSLIDE

### Dealing with runtime configurations

- CommandLineArguments
- use JsonUtility
    -> fast and easy text serialisation
- use ScriptableObjects
    -> save state and behaviour as asset

#HSLIDE

### CODING

#VSLIDE

### Events

- not UI only!
- event Action -> is a collection of typesafe generic function pointers
- UnityEvent -> is a Serializable collection of function generic function pointers 

#VSLIDE

### Events

Pros:

 - decouble through method signatures -> Callback functions
 - reduce amount of state variables

#VSLIDE 

### Events

Cons:

 - increased memory footprint (vs. direct calls)
 - don't forget to remove callbacks!

#VSLIDE
### Coroutines

- statefull methods
- recieving calls on different situations (EndOfFrame, Timer) 

#VSLIDE

### Coroutines

Pros:

 - Improve code clarity for state machines
 - distribute computing time over multiple frames

#VSLIDE 

### Coroutines

Cons:

 - increased memory footprint (vs. plain update calls)

#HSLIDE

### Editor scripting

- Domain/Problem specific extensions
- handy tools eg. creating concept graphics for publications using handles and Gizmos
- custom debugger for data graphs

#VSLIDE

### Building a custom debugger

- get rid of Debug.Log() messages for continuous values
- a window showing different states of several objects

#HSLIDE

### Further recommendations

- Check [Awesome-Unity](https://github.com/RyanNielson/awesome-unity) as a valuable resource
- Use [Post-Processing](https://github.com/Unity-Technologies/PostProcessing/wiki) to improve the image quality for demonstrators but do not use them for VR settings!

