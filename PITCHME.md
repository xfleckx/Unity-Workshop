### Using Unity for scientific demonstrators and research projects

#HSLIDE

### Contents

1. Setting up a project _(10 min)_
2. Delegating work with (git) submodules and prefabs _(30 min)_
3. Advanced coding tips for rapid prototyping
    1. UnityEvents _(10 min)_
    2. Coroutines _(20 min)_
    3. Linq _(20 min)_
4. Editor scripting and advanced debugging _(20 min)_

#HSLIDE

### Setting up project

Unity + git

#VSLIDE

- add [.gitignore](https://github.com/github/gitignore/blob/master/Unity.gitignore) 
- what we might learn from [ignore patterns](https://github.com/github/gitignore/blob/master/Unity.gitignore#L14-L17)
- exception: a plugin.dll

```shell
git add -f Assets/<fizzBuzz>/Plugins/<plugin>.dll
```


#VSLIDE

Pros:

- lean repositories (no code duplication in remotes)
- development branch could point to a development of the submodule

Cons: 

- more git commands necessary to manage the submodule

```shell
git clone ... -recursive
git submodule update --remote
```

- not possible with Projects maintained as whole Unity projects :(
- example: [HoloToolkit](https://github.com/Microsoft/HoloToolkit-Unity)

#VSLIDE

add a useful project as submodule...

```bash
git submodule add -b master 
                  --name UnityToolbag 
                  git://github.com/nickgravelyn/UnityToolbag.git 
                  ResearchDemonstrator/Assets/UnityToolbag 
```

#VSLIDE

What about project settings necessary for my asset package?

Use an EditorScript which sets required values... (SettingsExample.cs)

#VSLIDE

### Recommendations

- write a project setup script (python/bash/...) for new projects 
- import all useful repos as submodules (manually resolving your dependency graph)


#VSLIDE

- Reduce merge conflicts with prefabs are easier to solve

- _instances_ of *modified* prefabs marked red in scene hierarchy


Copy -> Change -> Ready to replace

#HSLIDE

### recommendations on Merge 

Close Unity before merging! (Dry merge)

Resolve conflicts


#HSLIDE

Each feature should be developed in an dedicated scene.
Dev-Scene in Development branch

Unity project depending on a _work in progress_ asset package

#VSLIDE?image=img/overview.png

#HSLIDE

### Using prefabs

- distinct logical entities 
- containing serialized state 
- state => value + references

#HSLIDE 

### Designing a prefab

- use a top level script as facade
- use public methods 
- use events for deferred or non-deterministic results 

#HSLIDE

### Coding hint

- use assertions to signal errors and corrupt prefab states

```csharp
using UnityEngine.Assertions;
Assert.IsNotNull(myExpectedReference,"Something is missing");
```
- don't worry - got removed on compile time during the build process!

#VSLIDE

### Dealing with runtime configurations

- use JsonUtility
- use ScriptableObjects

### CODING

#VSLIDE

### UnityEvents

#HSLIDE

### Coroutines

Pros:

 - Improve code clarity for state machines
 - distribute computing time over multiple frames

#VSLIDE 

### Coroutine 

Cons:

 - increased memory footprint (vs. plain update calls)


#HSLIDE

### Linq

#HSLIDE

### Editor scripting

- Domain/Problem specific extensions
- custom debugger for complex
#VSLIDE

### Building a custom debugger

- get rid of Debug.Log() messages
- a window showing different states of several objects



### Further recommendations

- Check [Awesome-Unity](https://github.com/RyanNielson/awesome-unity) as a valuable resource
- Use [Post-Processing](https://github.com/Unity-Technologies/PostProcessing/wiki) to improve the image quality for demonstrators
- but do not use them for VR settings!

